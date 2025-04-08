using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardMode : MonoBehaviour
{
    public void HardModeStart()
    {
        SceneManager.LoadScene("Game");
        CreateCard.GameMode = 1;
    }
}