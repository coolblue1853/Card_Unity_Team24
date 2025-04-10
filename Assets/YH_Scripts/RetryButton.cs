using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public GameObject Show_Button;
    public GameObject Start_Button;

    public GameObject Rtan_Image0;
    public GameObject Rtan_Image1;
    public GameObject Rtan_Image2;
    public GameObject Rtan_Image3;
    public GameObject Rtan_Image4;
    public GameObject Interaction_Buttons;

    int Image_State = 0;

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowButton()
    {
        Show_Button.SetActive(false);
        Start_Button.SetActive(false);

        Image_State = 0;
        Interaction_Buttons.SetActive(true);
    }

    public void Add_Imagenumber()
    {
        if (Image_State < 5)
        {
            SoundManagerSFX.Instance.ClickSd();
            Image_State++;
            Show_Image();
        }

    }

    public void Subtraction_Imagenumber()
    {
        if (Image_State > 0)
        {
            SoundManagerSFX.Instance.ClickSd();
            Image_State--;
            Show_Image();
        }

    }
    public void X_Button()
    {
        Show_Button.SetActive(true);
        Start_Button.SetActive(true);

        Image_State = 0;
        Interaction_Buttons.SetActive(false);
    }

    void Show_Image()
    {
        if (Image_State == 0)
        {
            Rtan_Image0.SetActive(true);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(false);
        }

        if (Image_State == 1)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(true);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(false);
        }

        if (Image_State == 2)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(true);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(false);
        }

        if (Image_State == 3)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(true);
            Rtan_Image4.SetActive(false);
        }

        if (Image_State == 4)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(true);
        }

    }

    void Update()
    {
      //  Show_Image();
    }
}
