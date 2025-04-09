using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score = 0;
    private static Score instance;

    private void Awake()
    {
        instance = this;
        UpdateText();
    }

    public static void PlusScore(int number)
    {
        score += number;
        instance.UpdateText();
    }

    private void UpdateText()
    {
        scoreText.text = score.ToString();
    }
}