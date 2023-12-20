using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float changeInterval = 2f;
    public float fleeDistance = 5f;

    private float elapsedTime = 0f;
    private Vector3 movementDirection;
    private GameObject crocodile;

    void Start()
    {
        movementDirection = GetRandomHorizontalDirection();

        crocodile = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (crocodile != null)
        {
            if (Vector3.Distance(transform.position, crocodile.transform.position) < fleeDistance)
            {
                FleeFromCrocodile();
            }
            else
            {
                MoveInNormalDirection();
            }
        }
        else
        {
            Debug.LogError("Krokodil nicht gefunden. Stelle sicher, dass der Tag des Krokodils auf 'Player' gesetzt ist.");
        }
    }

    void FleeFromCrocodile()
    {
        Vector3 fleeDirection = (transform.position - crocodile.transform.position).normalized;
        transform.Translate(fleeDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void MoveInNormalDirection()
    {
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= changeInterval)
        {
            ChangeMovementDirection();

            elapsedTime = 0f;
        }
    }

    void ChangeMovementDirection()
    {
        movementDirection = GetRandomHorizontalDirection();
    }

    Vector3 GetRandomHorizontalDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}