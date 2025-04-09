using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerSFX : MonoBehaviour
{
    public static SoundManagerSFX Instance;

    public AudioClip FlipSound;
    public AudioClip MatchSound;
    public AudioClip FailSound;

    AudioSource audiosource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void FlipSd()
    {
        audiosource.PlayOneShot(FlipSound);
    }
    public void MatchSd()
    {
        audiosource.PlayOneShot(MatchSound);
    }
    public void FailSd()
    {
        audiosource.PlayOneShot(FailSound);
    }
}
