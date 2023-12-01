using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public GameObject P1Win;
    public GameObject P2Win;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("P1"))
        {
            P1Win.SetActive(true);
        }
        if (collision.gameObject.CompareTag("P2"))
        {
            P2Win.SetActive(true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("P1"))
        {
            P1Win.SetActive(true);
        }
        if (collision.gameObject.CompareTag("P2"))
        {
            P2Win.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("P1"))
        {
            P1Win.SetActive(true);
        }
        if (collision.gameObject.CompareTag("P2"))
        {
            P2Win.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("P1"))
        {
            P1Win.SetActive(true);
        }
        if (other.gameObject.CompareTag("P2"))
        {
            P2Win.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("P1"))
        {
            P1Win.SetActive(true);
        }
        if (other.gameObject.CompareTag("P2"))
        {
            P2Win.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("P1"))
        {
            P1Win.SetActive(true);
        }
        if (other.gameObject.CompareTag("P2"))
        {
            P2Win.SetActive(true);
        }
    }
}
