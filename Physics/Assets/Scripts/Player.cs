using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    /// <summary>
    /// Players character controller
    /// </summary>
    CharacterController controller = null;

    /// <summary>
    /// Players speed
    /// </summary>
    public float speed = 80.0f;

    /// <summary>
    /// Players push power
    /// </summary>
    public float pushPower = 2.0f;

    /// <summary>
    /// Players velocity
    /// </summary>
    private Vector3 playerVelocity;

    /// <summary>
    /// Is the player on the ground
    /// </summary>
    [HideInInspector]
    public bool groundedPlayer;

    /// <summary>
    /// Is the player on the platform
    /// </summary>
    [HideInInspector]
    public bool playerOnPlatform;
    
    /// <summary>
    /// The gravity of the scene
    /// </summary>
    private float gravityValue = -9.81f;

    /// <summary>
    /// The player's jump height
    /// </summary>
    private float jumpHeight = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;

        // If the player is on the ground, set the velocity on the y axis to 0
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        // Allow player to move while facing forward
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        controller.Move(transform.forward * vertical * Time.deltaTime * speed);
        controller.Move(transform.right * horizontal * Time.deltaTime * speed);

        // If the player presses the jump button, make the players character jump
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // Apply gravity to player velocity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // If the player is on the platform, apply a huge amount of gravity to stop the player
        // from moving up and down on the platfrom
        if (playerOnPlatform && playerVelocity.y < 0)
        {
            playerVelocity.y = -100f;
        }
        else if (!playerOnPlatform && playerVelocity.y <= -90)
        {
            playerVelocity.y = 0;
        }

        // Move player based on velocity
        controller.Move(playerVelocity * Time.deltaTime);
    }

    /// <summary>
    /// OnControllerColliderHit is called when the controller hits a collider while performing a Move
    /// </summary>
    /// <param name="hit">Game object that the controller has hit</param>
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Get the rigidbody of the gameobject
        Rigidbody body = hit.collider.attachedRigidbody;

        // If one doesn't exist or is kinematic, then exit the function
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3f)
            return;

        // The direction to apply push
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Apply push
        body.velocity = pushDir * pushPower;
    }
}
