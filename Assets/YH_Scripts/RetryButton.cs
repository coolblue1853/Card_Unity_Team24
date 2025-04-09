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
    public GameObject Rtan_Image5;
    public GameObject Rtan_Image6;
    public GameObject Rtan_Image7;

    public GameObject Interaction_Buttons;

    int Image_State = 10;

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
        if (Image_State < 7)
        {
            Image_State++;
        }  
    }

    public void Subtraction_Imagenumber()
    {
        if (Image_State > 0)
        {
            Image_State--;
        } 
    }
    public void X_Button()
    {
        Show_Button.SetActive(true);
        Start_Button.SetActive(true);

        Image_State = 10;
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
            Rtan_Image5.SetActive(false);
            Rtan_Image6.SetActive(false);
            Rtan_Image7.SetActive(false);
        }

        if (Image_State == 1)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(true);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(false);
            Rtan_Image5.SetActive(false);
            Rtan_Image6.SetActive(false);
            Rtan_Image7.SetActive(false);
        }

        if (Image_State == 2)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(true);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(false);
            Rtan_Image5.SetActive(false);
            Rtan_Image6.SetActive(false);
            Rtan_Image7.SetActive(false);
        }

        if (Image_State == 3)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(true);
            Rtan_Image4.SetActive(false);
            Rtan_Image5.SetActive(false);
            Rtan_Image6.SetActive(false);
            Rtan_Image7.SetActive(false);
        }

        if (Image_State == 4)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(true);
            Rtan_Image5.SetActive(false);
            Rtan_Image6.SetActive(false);
            Rtan_Image7.SetActive(false);
        }

        if (Image_State == 5)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(false);
            Rtan_Image5.SetActive(true);
            Rtan_Image6.SetActive(false);
            Rtan_Image7.SetActive(false);
        }

        if (Image_State == 6)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(false);
            Rtan_Image5.SetActive(false);
            Rtan_Image6.SetActive(true);
            Rtan_Image7.SetActive(false);
        }

        if (Image_State == 7)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(false);
            Rtan_Image5.SetActive(false);
            Rtan_Image6.SetActive(false);
            Rtan_Image7.SetActive(true);
        }

        if (Image_State == 10)
        {
            Rtan_Image0.SetActive(false);
            Rtan_Image1.SetActive(false);
            Rtan_Image2.SetActive(false);
            Rtan_Image3.SetActive(false);
            Rtan_Image4.SetActive(false);
            Rtan_Image5.SetActive(false);
            Rtan_Image6.SetActive(false);
            Rtan_Image7.SetActive(false);
        }
    }

    void Update()
    {
        Show_Image();
    }
}
