using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShowSetting : MonoBehaviour
{
    public GameObject settingUI;
    public void Click()
    {
        
        SoundManagerSFX.Instance.ClickSd();
        settingUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void Close()
    {
        SoundManagerSFX.Instance.ClickSd();
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void GoMain()
    {
        SoundManagerSFX.Instance.ClickSd();
        SceneManager.LoadScene("Start");
    }
}
