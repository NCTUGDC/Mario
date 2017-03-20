using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBehavior : GeneratedObjectBehavior
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            if(other.relativeVelocity.y == 0)

            //if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) < 0.01f)
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-100, 0, 0));
        }
        else
        {
            other.gameObject.transform.localScale = other.gameObject.transform.localScale * 1.1f;
            GameManager.Instance.GetScore(10);
            PlayerStatusManager.Instance.GainLife(1);
            Destroy(gameObject);
        }
    }

}
