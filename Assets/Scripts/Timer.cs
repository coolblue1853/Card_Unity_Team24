using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    float time = 20.0f;

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        time -= Time.deltaTime;
        timerText.text = time.ToString("N2");
    }
}
