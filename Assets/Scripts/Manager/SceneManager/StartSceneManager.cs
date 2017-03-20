using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    private void Start()
    {
        GameObject ducks = GameObject.Find("Ducks");
        foreach (Transform duck in ducks.transform)
        {
            StartCoroutine(DuckJumping(duck.gameObject, Random.Range(0.1f, 0.2f)));
        }
    }

    IEnumerator DuckJumping(GameObject duck , float timeInterval)
    {
        float passTime = 0f;

        while(true)
        {
            passTime += Time.deltaTime;
            if (passTime >= timeInterval)
            {
                if (Mathf.Abs(duck.GetComponent<Rigidbody2D>().velocity.y) > 0)
                {
                    // still in air
                }
                else
                {
                    duck.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 200, 0));
                }
                passTime = 0f;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void ToNextScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}