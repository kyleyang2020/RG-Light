using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGLight : MonoBehaviour
{
    public AudioClip redLight;
    public AudioClip greenLight;
    public AudioSource audioSource;

    public GameObject player;
    private bool gameStart = false;
    private float timer;

    private void Start()
    {
        timer = Time.time;
        audioSource = GetComponent<AudioSource>();
        StartGreenLight();
    }

    private void Update()
    {

    }

    private void StartGreenLight()
    {
        audioSource.PlayOneShot(greenLight);
        gameStart = true;
        StartCoroutine(PlayGame());
    }

    IEnumerator PlayGame()
    {
        float rangeRed = Random.Range(1f, 4.3f);
        yield return new WaitForSeconds(rangeRed);
        audioSource.PlayOneShot(redLight);
        Update();
        yield return null;

        float rangeGreen = Random.Range(2f, 4f);
        yield return new WaitForSeconds(rangeGreen);
        audioSource.PlayOneShot(greenLight);
        Update();
        yield return null;
    }
}
