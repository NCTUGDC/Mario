using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingBoxBehavior : MonoBehaviour
{
    [SerializeField]
    private int canBeTriggerTimes;
    [SerializeField]
    private GameObject generatingObject;

    private bool CheckAble(Collider2D other)
    {
        if (other.tag != "Player") return false;
        if (other.GetComponent<Rigidbody2D>().velocity.y <= 0) return false;
        if (canBeTriggerTimes == 0) return false;

        return true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckAble(other) == false) return;

        canBeTriggerTimes--;

        if (canBeTriggerTimes == 0)
            transform.parent.GetComponent<SpriteRenderer>().color -= new Color(0.5f, 0.5f, 0.5f, 0f);

        GameObject obj = Instantiate(generatingObject);
        obj.GetComponent<GeneratedObjectBehavior>().generator
            = gameObject.transform.parent.gameObject;
        StartCoroutine(GeneratingObject(obj));
    }
    IEnumerator GeneratingObject(GameObject obj)
    {
        float passTime = 0f;
        float timeInterval = 0.5f;

        obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        obj.GetComponent<Collider2D>().enabled = false;
        obj.transform.SetParent(transform);

        while (passTime < timeInterval)
        {
            passTime += Time.deltaTime;
            obj.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 1f, 1), passTime / timeInterval);

            yield return null;
        }

        obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        obj.GetComponent<Collider2D>().enabled = true;
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector3(50, 0, 0));

    }

}