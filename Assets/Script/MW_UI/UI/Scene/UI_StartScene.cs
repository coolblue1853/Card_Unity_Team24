using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_StartScene : UI_Scene
{
    enum Texts
    {
        TitleText
    }
    enum Buttons
    {
        NomalModeButton,
        HardModeButton,
        QuitButton,
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        Get<Button>((int)Buttons.NomalModeButton).onClick.AddListener(EazyModeStart);
        Get<Button>((int)Buttons.HardModeButton).onClick.AddListener(HardModeStart);
        Get<Button>((int)Buttons.QuitButton).onClick.AddListener(OnQuitButtonClick);

    }

    protected void EazyModeStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void HardModeStart()
    {
        SceneManager.LoadScene("Game");
        CreateCard.GameMode = 1;
    }
    protected void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
