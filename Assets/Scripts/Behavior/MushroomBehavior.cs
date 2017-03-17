using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBehavior : GeneratedObjectBehavior
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player") return;

        other.gameObject.transform.localScale = other.gameObject.transform.localScale * 1.1f;
        GameManager.Instance.GetScore(10);
        Destroy(gameObject);
    }

}
