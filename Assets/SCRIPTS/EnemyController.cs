using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform playerTransform;
    public float movementSpeed = 5f;
    //public GameObject GameOverScreen;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            Vector3 normalizedDirection = directionToPlayer.normalized;

            transform.Translate(normalizedDirection * movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CrocodileController crocodileController = other.GetComponent<CrocodileController>();
            if (crocodileController != null)
            {
                crocodileController.HandleEnemyCollision();
                //GameOverScreen.SetActive(true);
            }
        }
    }
}