using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timer;
    public GameObject gameOverText;

    float time = 20.00f;

    void Start()
    {
        gameOverText.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void GameOver()
    {
        gameOverText.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void Update()
    {
        if (time > 0.0f)
        {
            time -= Time.deltaTime;
            timer.text = time.ToString("N2");
        }
        else
        {
            GameOver();
        }
    }
}