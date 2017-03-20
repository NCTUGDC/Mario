using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject PlayerGameObject { get; private set; }

    public int Score { get; private set; }
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject gameOverPanel;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);

        InitialSetting();
        DontDestroyOnLoad(gameObject);
    }

    private void InitialSetting()
    {
        GetScore(0);
        PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void GetScore(int scoreOffset)
    {
        Score += scoreOffset;
        scoreText.text = string.Format("Score = {0}", Score);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Destroy(PlayerGameObject);
    }

    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
