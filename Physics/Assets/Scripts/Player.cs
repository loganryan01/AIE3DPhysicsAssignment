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
    private float gravityValue = -9.81f;

    private bool groundedPlayer;

    private Vector3 playerVelocity;

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

        Vector3 move = new Vector3(horizontal, 0, vertical);
        controller.Move(transform.forward * vertical * Time.fixedDeltaTime * speed);
        controller.Move(transform.right * horizontal * Time.fixedDeltaTime * speed);

        playerVelocity.y += gravityValue * Time.fixedDeltaTime;
        controller.Move(playerVelocity * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3f)
            return;
    }
}
