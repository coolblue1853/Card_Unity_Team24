using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        UIManager.instance.SetCanvas(gameObject, true);
    }

    public virtual void ClosePopUI()
    {
        UIManager.instance.ClosePopupUI(this);
    }
}
