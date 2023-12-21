using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class croco : MonoBehaviour
{
    public static Vector3 currentPos;
    private Animator animator;
    public float rotationSpeed, speed, chompDistance;
    private float newRotation, holdDuration;
    public GameObject arrow;
    public static bool isAlive;
    private bool isRotating, isChomping;
    public Material material;
    public Texture zero,one,two,three;
    private Vector3 targetPos;
    public Text scoreText;
    public GameObject GameOverScreen;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        holdDuration = 0f;
        material.mainTexture = zero;
        isChomping = false;
        isAlive = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isAlive)
        {
            isRotating = true;
            animator.SetBool("isCharging", true);
            StartCoroutine(arrows());

        }
        if (Input.GetButtonUp("Jump") && isAlive)
        {
            isRotating = false;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, arrow.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            
            animator.SetBool("isCharging", false);
            material.mainTexture = zero;
            StopCoroutine(arrows());
            targetPos = transform.position + transform.forward * holdDuration * chompDistance;
            isChomping = true;
            holdDuration = 0f;
        }

        if(isRotating)
        {
            holdDuration += Time.deltaTime * rotationSpeed;
            arrow.transform.Rotate(Vector3.up, holdDuration);
        }
        else
        {
            material.mainTexture = zero;
        }

        if(isChomping)
        {
            animator.SetBool("isChomping", true);
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
            if(transform.position == targetPos)
            {
                animator.SetBool("isChomping", false);
                isChomping = false;
            }
        }
       
    }


    IEnumerator arrows()
    {
            material.mainTexture = one;
        if(isRotating)
        {
            yield return new WaitForSeconds(1);
            material.mainTexture = two;
        }
        else
        {
            material.mainTexture = zero;
        }
          
        if (isRotating)
        {
            yield return new WaitForSeconds(1);
            material.mainTexture = three;
        }
        else
        {
            material.mainTexture = zero;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (isAlive && other.CompareTag("Fish"))
        {
            Destroy(other.gameObject);

            score += 1;

            scoreText.text = "Gefressene Fische: " + score;
        }

        if (isAlive && other.CompareTag("Enemy"))
        {
            Debug.Log("ouch");
            isAlive = false;
            StartCoroutine(DeathAnimation());
        }
    }

    IEnumerator DeathAnimation()
    {
        animator.SetTrigger("Tot");

        yield return new WaitForSeconds(2f);

        GameOverScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}

