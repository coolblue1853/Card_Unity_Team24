using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;
using UnityEngine.SceneManagement;

public class UI_EndGame : UI_Popup
{
    enum Buttons
    {
        GoStartButton
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));  

        Button goStartButton = Get<Button>((int)Buttons.GoStartButton);
        goStartButton.onClick.AddListener(OnGoMainButtonClicked);

        //SetPivot(pos, Get<RectTransform>((int)Pivot.Pivot));
    }
    protected void OnGoMainButtonClicked()
    {
        SceneManager.LoadScene("Start");
    }
}
