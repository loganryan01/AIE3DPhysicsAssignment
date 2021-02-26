using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
//[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    CharacterController controller = null;

    public float speed = 80.0f;
    public float pushPower = 2.0f;

    private Vector3 playerVelocity;

    [HideInInspector]
    public bool groundedPlayer;
    [HideInInspector]
    public bool playerOnPlatform;
    private float gravityValue = -9.81f;
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
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        controller.Move(transform.forward * vertical * Time.deltaTime * speed);
        controller.Move(transform.right * horizontal * Time.deltaTime * speed);

        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        if (playerOnPlatform && playerVelocity.y < 0)
        {
            playerVelocity.y = -100f;
        }
        else if (!playerOnPlatform && playerVelocity.y <= -90)
        {
            playerVelocity.y = 0;
        }

        Debug.Log(playerVelocity);

        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3f)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = pushDir * pushPower;
    }
}
