using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override void Init()
    {
        if(UIManager.instance == null)
        {
            GameObject go = new GameObject("UIManager");
            go.AddComponent<UIManager>();
        }
        if (SoundManager.instance == null)
        {
            GameObject go = new GameObject("SoundManager");
            go.AddComponent<SoundManager>();
        }
    }


}
