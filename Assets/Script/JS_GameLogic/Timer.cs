using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;

    public static float time = 50.00f;

    private void Update()
    {
        if (GameManager.Instance.isCanFlip == false) return;
        if (GameManager.Instance.isGameEnded == true) return;

        if (time > 0.0f)
        {
            time -= Time.deltaTime;
            timer.text = time.ToString("N2");

            if (GameManager.Instance.cardCount <= 0)
            {
                if (Score.score >= Score.standardScore)
                    GameManager.Instance.StartHiddenGame();
                else
                    GameManager.Instance.GameClear();
            }
        }
        else
        {
            GameManager.Instance.GameOver();
        }
    }
}