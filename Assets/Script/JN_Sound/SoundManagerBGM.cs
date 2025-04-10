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
    public bool isHidden = false;
    private void OnEnable()
    {
        isHidden = false;
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

        if (currentScene == "Game")
        {
            if(audiosource.clip == this.FeverBgm)
            {
                isHidden = true;
            }
            else if (Timer.time <= 15f && time>0)
            {
                if(!Iswarningplay)
                {
                    audiosource.PlayOneShot(WarningSound);
                    Iswarningplay = true;
                    playtime = Timer.time;
                }
                if(playtime- Timer.time >= 0.9f)
                {
                    Iswarningplay = false;
                }
            }
            else if(Timer.time <= 0)
            {
                audiosource.Stop();
            }
        }
        else if (currentScene == "Game"&& (audiosource.isPlaying == false || audiosource.clip != GameBgm || isHidden == false))
        {
            audiosource.clip = this.GameBgm;
            audiosource.Play();
        }

    }
    public void FevertimeBgm()
    {
        isHidden = true;
        audiosource.clip = this.FeverBgm;
        audiosource.Play();
    }
}