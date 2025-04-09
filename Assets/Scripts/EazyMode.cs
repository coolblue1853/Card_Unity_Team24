using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EazyMode : MonoBehaviour
{
    public void EazyModeStart()
    {
        SceneManager.LoadScene("Game");
    }
}