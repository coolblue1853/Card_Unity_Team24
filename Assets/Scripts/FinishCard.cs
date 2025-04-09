using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FinishCard : MonoBehaviour
{
    public SpriteRenderer sp;
    public void Setting(int number)
    {
        var loaded = Resources.Load<Sprite>(number.ToString());
        //if (loaded == null)
        //{
        //    Debug.LogError($"[Setting] {number}�� ��������Ʈ�� ã�� �� �����ϴ�!");
        //    return;
        //}
        sp.sprite = loaded;
    }
}
