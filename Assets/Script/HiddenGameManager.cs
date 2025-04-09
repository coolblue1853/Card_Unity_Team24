using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenGameManager : MonoBehaviour
{
    float feverTime = 0;
    public Text feverTimeScoretxt;

    void Start()
    {
        
    }

    void Update()
    {
        feverTime += Time.deltaTime;
        feverTimeScoretxt.text = ((int)feverTime).ToString();
    }
}
