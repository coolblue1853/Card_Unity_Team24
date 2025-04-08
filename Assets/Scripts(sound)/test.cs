using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public void Flip()
    {
        SoundManagerSFX.Instance.FlipSd();
    }
    public void Fever()
    {
        SoundManagerBGM.Instance.FevertimeBgm();
    }
    public void Match()
    {
        SoundManagerSFX.Instance.MatchSd();
    }
    public void Fail()
    {
        SoundManagerSFX.Instance.FailSd();
    }
}
