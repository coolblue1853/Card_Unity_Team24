using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }
}
