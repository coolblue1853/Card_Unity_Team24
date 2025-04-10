using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score = 0;
    public static int standardScore = 150;
    public static int addScore = 0;
    public static Score instance;

    private void Awake()
    {
        scoreText.text = "";
        score = 0;
        addScore = 0;
        if (instance == null)
            instance = this;
        
        UpdateText();
    }
    public int GetSocre()
    {
        return score;
    }
    public int GetAddSocre()
    {
        return addScore;
    }
    public void SetAddScore(int _addScore)
    {
        addScore = _addScore;
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