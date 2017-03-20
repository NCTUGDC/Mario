using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingBoxBehavior : MonoBehaviour
{
    [SerializeField]
    private Sprite readySprite;
    [SerializeField]
    private Sprite inCoolDownSprite;

    private float coolDown = 0f;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player") return;

        if (coolDown <= 0)
        {
            PlayerStatusManager.Instance.LoseLife();
            coolDown = 2f;
            gameObject.GetComponent<SpriteRenderer>().sprite = inCoolDownSprite;
        }
    }

    private void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
            if(coolDown <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = readySprite;
            }
        }
    }
}
