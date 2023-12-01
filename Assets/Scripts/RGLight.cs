using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RGLight : MonoBehaviour
{
    public AudioClip redLight;
    public AudioClip greenLight;

    public Transform P1Transform;
    public Transform P2Transform;

    public GameObject P1GameObject;
    public GameObject P2GameObject;

    private bool killBool;
    private bool P1moving, P2moving;

    public float timeLimit;
    private float redTimer, greenTimer;

    private bool isRed, isGreen = false;
    private AudioSource audioSource;

    private Vector3 saveP1Pos, saveP2Pos, currentP1Pos, currentP2Pos;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isGreenLight();
        redTimer = Random.Range(1f, 4f);
        greenTimer = Random.Range(2f, 6f);
    }

    private void Update()
    {
        timeLimit = timeLimit - Time.deltaTime;

        if (timeLimit < 0f)
        {
            timeLimit = 0f;
            Debug.Log("DONE");
        }

        // when light is red checks if player is moving then set moving to true
        if(isRed)
        {
            Debug.Log("player check");
            currentP1Pos = new Vector3(P1Transform.position.x, P1Transform.position.y, P1Transform.position.z);
            currentP2Pos = new Vector3(P2Transform.position.x, P2Transform.position.y, P2Transform.position.z);

            if ((currentP1Pos - saveP1Pos).magnitude > 0f)
                P1moving = true;
            if ((currentP2Pos - saveP2Pos).magnitude > 0f)
                P2moving = true;
        }
        
        // when light is red, and random time has passed as red light, turn green
        if (isRed)
        {
            redTimer = redTimer - Time.deltaTime;
            if(redTimer < 0f) 
            {
                isGreenLight();
                killBool = false;
                redTimer = Random.Range(1f, 4f);
            }
        }

        // when light is green, and random time has passed as green light, turn red
        else if (isGreen)
        {
            greenTimer = greenTimer - Time.deltaTime;
            saveP1Pos = new Vector3(P1Transform.position.x, P1Transform.position.y, P1Transform.position.z);
            saveP2Pos = new Vector3(P2Transform.position.x, P2Transform.position.y, P2Transform.position.z);
            if (greenTimer < 0f)
            {
                isRedLight();
                killBool = true;
                greenTimer = Random.Range(2f, 6f);
            }
        }
    }

    // updates bool for update and plays red sound
    private void isRedLight()
    {
        isRed = true;
        isGreen = false;
        audioSource.PlayOneShot(redLight);
        Debug.Log("red");
    }

    // updates bool for update and plays green sound
    private void isGreenLight()
    {
        isRed = false;
        isGreen = true;
        audioSource.PlayOneShot(greenLight);
        Debug.Log("green");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (killBool && P1moving)
            P1GameObject.SetActive(false);
        if (killBool && P2moving)
            P2GameObject.SetActive(false);
    }
}
