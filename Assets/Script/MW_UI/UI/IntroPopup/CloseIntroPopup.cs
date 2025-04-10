using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseIntroPopup : MonoBehaviour
{
    public GameObject introPopup;
    static bool isClosed = false;

    private void Start()
    {
        if (isClosed)
        {
            gameObject.SetActive(false);
        }
    }
    public void Close()
    {
        if (!isClosed)
        {         
            SoundManagerSFX.Instance.ClickSd();
            gameObject.SetActive(false);
            Time.timeScale = 1;

            isClosed = true;
        }
    }
}
