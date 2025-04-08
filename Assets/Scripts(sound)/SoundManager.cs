using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool isstratGame = false;

    public static SoundManager Instance; 

    AudioSource audiosource;

    public AudioClip MainBgm;
    public AudioClip GameBgm;
    public AudioClip FlipSound;
    public AudioClip MatchSound;
    public AudioClip FailSound;

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
        if (!isstratGame)
        {
            audiosource.clip = this.MainBgm;
            audiosource.Play();
        }
        else if(isstratGame)
        {
            audiosource.clip = this.GameBgm;
            audiosource.Play();
        }
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
