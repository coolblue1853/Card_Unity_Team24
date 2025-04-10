using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenGameManager : MonoBehaviour
{
    public static HiddenGameManager Instance;
    public Text feverTimeScoretxt;
   // public Text backgroundScoretxt;
    public float score;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    float feverTime = 0;
  
    void Update()
    {
        score  += Time.deltaTime;
        feverTimeScoretxt.text = ((int)score).ToString();
       // backgroundScoretxt.text = (score).ToString();
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
        Score.addScore = (int)score;
        GameManager.Instance.GameClear();
    }
}
