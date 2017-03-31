using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Invoke("SelfDestroy" , 0.5f);
    }
    
    void SelfDestroy()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        gameObject.GetComponent<Collider2D>().isTrigger = true;

        Destroy(gameObject, 1.5f);
    }
}