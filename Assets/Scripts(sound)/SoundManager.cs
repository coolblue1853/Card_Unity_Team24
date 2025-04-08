using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; 

    AudioSource audiosource;

    public AudioClip MainBgm;
    public AudioClip GameBgm;
    public AudioClip FeverBgm;
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
        string currentScene = SceneManager.GetActiveScene().name;
        audiosource = GetComponent<AudioSource>();
        if (currentScene == "Start")
        {
            audiosource.clip = this.MainBgm;
            audiosource.Play();
        }
        else if(currentScene == "Game")
        {
            audiosource.clip = this.GameBgm;
            audiosource.Play();
        }
    }

    public void FevertimeBgm()
    {
        audiosource.clip = this.FeverBgm;
        audiosource.Play();
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
