using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public abstract void Init();
    private void Start()
    {
        Init();
    }
}
