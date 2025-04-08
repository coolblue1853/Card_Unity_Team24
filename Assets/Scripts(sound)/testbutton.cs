using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testbutton : MonoBehaviour
{

    public void flip()
    {
        SoundManager.Instance.FlipSd();
    }
    public void match()
    {
        SoundManager.Instance.MatchSd();
    }
    public void fail()
    {
        SoundManager.Instance.FailSd();
    }
}
