using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; 
    AudioSource audiosource;
    public AudioClip MainBgm;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//scene을 이동해도 audio가 파괴안되게
        }
        else
        {
            Destroy(gameObject);
        }
    }



    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = this.MainBgm;
        audiosource.Play();
    }
}
