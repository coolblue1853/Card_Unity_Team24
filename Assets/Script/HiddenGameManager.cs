using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenGameManager : MonoBehaviour
{
    public static HiddenGameManager Instance;
    public Text feverTimeScoretxt;
    public Text backgroundScoretxt;

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
        feverTime += Time.deltaTime;
        feverTimeScoretxt.text = ((int)feverTime).ToString();
        backgroundScoretxt.text = ((int)feverTime).ToString();
    }

    public void GameEnd()
    {
        Time.timeScale = 0;

    }
}
