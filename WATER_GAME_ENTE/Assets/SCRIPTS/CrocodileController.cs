using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrocodileController : MonoBehaviour
{
    public float rotationSpeedMultiplier = 5f;
    public float flightDistanceMultiplier = 5f;

    private bool isRotating = false;
    private Vector3 rotationDirection;
    private float rotationSpeed;
    private float flightDistance;
    private float pressTime;

    public Text scoreText;
    private int score = 0;

    public Animator Anim_Death;
    public GameObject GameOverScreen;

    private bool isAlive = true;

    void Update()
    {
        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isRotating = true;
                rotationDirection = transform.forward;
                pressTime = Time.time;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isRotating = false;

                Vector3 destination = transform.position + rotationDirection * flightDistance;
                StartCoroutine(FlyToDestination(destination));
            }

            if (isRotating)
            {
                float holdDuration = Time.time - pressTime;
                rotationSpeed = holdDuration * rotationSpeedMultiplier;
                flightDistance = holdDuration * flightDistanceMultiplier;

                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

                rotationDirection = transform.forward;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAlive && other.CompareTag("Fish"))
        {
            Destroy(other.gameObject);

            score += 1;

            UpdateScoreUI();
        }

        if (isAlive && other.CompareTag("Enemy"))
        {
            HandleEnemyCollision();
        }
    }

    IEnumerator FlyToDestination(Vector3 destination)
    {
        float elapsedTime = 0f;
        float duration = 2f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(transform.position, destination, elapsedTime / duration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = destination;
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Gefressene Fische: " + score;
    }

    public void HandleEnemyCollision()
    {
        isAlive = false;
        StartCoroutine(DeathAnimation());
    }

    IEnumerator DeathAnimation()
    {
        Anim_Death.SetTrigger("Tot");

        yield return new WaitForSeconds(2f);

        GameOverScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}