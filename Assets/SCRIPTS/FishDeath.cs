using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDeath : MonoBehaviour
{
    public void DestroyFish()
    {
        Destroy(gameObject);
    }
}