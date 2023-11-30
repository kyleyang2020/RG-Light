using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        // takes the transform of the FP camera and apply it to the camera
        // so the camera moves with the player
        transform.position = cameraPosition.position;
    }
}
