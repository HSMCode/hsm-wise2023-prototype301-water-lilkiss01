using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    private Transform playerPos;
    private Renderer Renderer;
    private float offsetX, offsetY;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Crocodile").transform;
        Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offsetX = (playerPos.position.x - transform.position.x) / (2.5f * 1.74f * transform.localScale.x);
        offsetY = (playerPos.position.z - transform.position.z) / (2.5f * 1.74f * transform.localScale.z);
        Renderer.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}
