using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{

    private Transform player;
    public float moveSpeed = 1.0f;
    public float rotationSpeed = 5.0f;
    private Vector3 randomDirection;
    public Vector3 Direction;
    private float distance;
    private bool random = true;

    private void Start()
    {
        player = GameObject.Find("Crocodile").transform;
        Direction = new Vector3(0, 0, 0.002f);
        InvokeRepeating("GetRandomDirection", 0f,2f);
        InvokeRepeating("randomtrue", 0f, 6f);
        InvokeRepeating("randomfalse", 3f, 6f);

    }
    void Update()
    {
        if (random == false)
        { 
            transform.LookAt(player);
            transform.Translate(Direction);
        }

        if (random == true)
        {

            transform.Translate(randomDirection * (moveSpeed / 2) * Time.deltaTime, Space.World);


            if (randomDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(randomDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        distance = Vector3.Distance(player.position, transform.position);
        if (distance > 18f)
        {
            Destroy(gameObject);
        }
    }

    void GetRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    void randomtrue()
    {
        random = true;
    }
    void randomfalse()
    {
        random = false;
    }
}

   


   

   

