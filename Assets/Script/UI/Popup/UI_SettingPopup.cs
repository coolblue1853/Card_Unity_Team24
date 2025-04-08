using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_SettingPopup : UI_Popup
{
    enum Sliders
    {
        BGMSlider,
        SFXSlider
    }
    enum Buttons
    {
        PointButton
    }
    public override void Init()
    {
        base.Init();

        // 버튼과 바인드
        Bind<Button>(typeof(Buttons));

        Button btn = Get<Button>((int)Buttons.PointButton);
        Get<Button>((int)Buttons.PointButton).onClick.AddListener(OnPointButtonClicked);

    }

    protected void OnPointButtonClicked()
    {

    }
}
