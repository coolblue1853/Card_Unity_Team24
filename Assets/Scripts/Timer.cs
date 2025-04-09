using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;

    float time = 1.00f;

    private void Update()
    {
        if (GameManager.Instance.isGameEnded == true) return;

        if (time > 0.0f)
        {
            time -= Time.deltaTime;
            timer.text = time.ToString("N2");

            if (GameManager.Instance.cardCount <= 0)
            {
                GameManager.Instance.GameClear();
            }
        }
        else
        {
            GameManager.Instance.GameOver();
        }
    }
}