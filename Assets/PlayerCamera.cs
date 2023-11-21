using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform orientation; // stores direction player is facing
    float xRotation, yRotation; // axis of camera for rotation
    public float sensX, sensY; // mouse sens x and y

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // locks the cursor in the middle of the screen
        Cursor.visible = false; // makes cursor invisible
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // rotation of camera, e.g, up/down, left/right
        yRotation += mouseX;
        xRotation -= mouseY;
        // make it so you dont break your neck looking too up or down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation for player and camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
