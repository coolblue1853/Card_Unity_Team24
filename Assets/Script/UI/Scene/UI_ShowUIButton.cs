using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
public class UI_ShowUIButton : UI_Scene
{
    [SerializeField]
    private string uiName;
    private GameObject popupUI;
    enum Buttons
    {
        PointButton
    }
    public override void Init()
    {
        base.Init();
        uiName = gameObject.name.Replace("Button", "UI");

        // ��ư�� ���ε�
        Bind<Button>(typeof(Buttons));

        Button btn = Get<Button>((int)Buttons.PointButton);
        Get<Button>((int)Buttons.PointButton).onClick.AddListener(OnPointButtonClicked);

    }

    protected void OnPointButtonClicked()
    {
        if(popupUI == null)
        {
            popupUI = UIManager.instance.ShowPopupUI(uiName);
        }
        else
        {
            popupUI.SetActive(true);
        }

    }
}
