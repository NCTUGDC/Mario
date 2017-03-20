using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    public static PlayerStatusManager Instance { get; private set; }
    [SerializeField]
    private int life = 1;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void GainLife(int delta)
    {
        if (delta < 0) return;

        life += delta;
    }

    public void LoseLife()
    {
        life -= 1;
        print("loseLife");

        GameManager.Instance.PlayerGameObject.transform.localScale /= 1.1f;

        if(life == 0)
        {
            print("GG");
            GameManager.Instance.GameOver();
        }
    }

}