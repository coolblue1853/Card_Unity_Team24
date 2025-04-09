using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void RetryFunction()
    {
        CreateCard.GameMode = 0;
        Score.score = 0;
        Timer.time = 20.0f;
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene("Start");
    }
}