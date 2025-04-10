using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManagerSFX : MonoBehaviour
{
    public static SoundManagerSFX Instance;

    public AudioClip FlipSound;
    public AudioClip MatchSound;
    public AudioClip FailSound;
    public AudioClip Click;
    public AudioClip Intro;
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
        if(SceneManager.GetActiveScene().name == "Logo")
        {
            IntroSd();
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
    public void ClickSd ()
    {
        audiosource.PlayOneShot(Click);
    }
    public void IntroSd()
    {
        audiosource.PlayOneShot(Intro);
    }
}
