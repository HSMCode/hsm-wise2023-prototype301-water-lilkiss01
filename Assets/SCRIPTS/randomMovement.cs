using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RandomMovement : MonoBehaviour
{

    private Transform player;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 5.0f;
    private Vector3 randomDirection;
    public Vector3 Direction;
    private float distance;

    private void Start()
    {
        player = GameObject.Find("Crocodile").transform;
        InvokeRepeating("GetRandomDirection", 0f, 2f);
        

    }
    void Update()
    {
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime, Space.World);
        distance = Vector3.Distance(player.position, transform.position);

        if (randomDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(randomDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        if(distance > 18f)
        {
            Destroy(gameObject);
        }
    }

    void GetRandomDirection()
    {
       randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}
