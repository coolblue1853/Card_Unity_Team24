using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManagerBGM : MonoBehaviour
{
    public static SoundManagerBGM Instance;


    AudioSource audiosource;

    public AudioClip MainBgm;
    public AudioClip GameBgm;
    public AudioClip FeverBgm;

    public AudioClip WarningSound;


    float time = 20.0f;
    string currentScene;
    bool Iswarningplay = false;
    float playtime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
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
    void Update()
    {
        time -= Time.deltaTime;
        if (currentScene == "Game")
        {
            if(audiosource.clip == this.FeverBgm)
            {
                time = 0;
            }
            else if (time <= 6.3f && time>0)
            {
                if(!Iswarningplay)
                {
                    audiosource.PlayOneShot(WarningSound);
                    Iswarningplay = true;
                    playtime = time;
                }
                if(playtime-time>=0.9f)
                {
                    Iswarningplay = false;
                }
            }
            else if(time <=0)
            {
                audiosource.Stop();
            }
        }
    }
    public void FevertimeBgm()
    {
        audiosource.clip = this.FeverBgm;
        audiosource.Play();
    }
}