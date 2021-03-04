using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    /// <summary>
    /// Rotation on the x axis
    /// </summary>
    float rotationOnX;

    /// <summary>
    /// Sensitivity of rotation
    /// </summary>
    public float mouseSensitivity = 90f;

    /// <summary>
    /// Player object's transform
    /// </summary>
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // Hide mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse y position
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        // Mouse x position
        float m_X = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

        // Calculate x rotation
        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);

        // Rotate player
        player.Rotate(Vector3.up * m_X);
    }
}
