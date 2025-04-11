using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
class Animal
{
    protected virtual void Bark()
    {
        Debug.Log("!!!");
    }
}

class Dog : Animal
{
    protected override void Bark()
    {
        base.Bark();
        // �߰� ~~~
    }
}

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource bgmSource;
    [SerializeField]
    private AudioSource sfxSource;


    public float BgmVolume { get { return bgmSource.volume; } }
    public float SfxVolume { get { return sfxSource.volume; } }


    public static SoundManager instance;
    private void Awake()
    {
        // �̱���
        if (null == instance)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);

        Init();
    }

    private void Init()
    {
        // �׽�Ʈ��
        if (transform.Find("BFM") == null)
        {
            GameObject go = new GameObject("BGM");
            go.transform.parent = transform;
            go.AddComponent<AudioSource>();
            bgmSource = go.GetComponent<AudioSource>();
            bgmSource.loop = true;
        }

        if (transform.Find("SFX") == null)
        {
            GameObject go = new GameObject("SFX");
            go.transform.parent = transform;
            go.AddComponent<AudioSource>();
            sfxSource = go.GetComponent<AudioSource>();
        }
        bgmSource.clip = Resources.Load<AudioClip>($"Sound/{SceneManager.GetActiveScene().name}Bgm"); // �⺻ BGM
        if (bgmSource.isPlaying == false)
            bgmSource.Play();
    }


    // ���� �ε�� �� �ڵ����� ȣ��Ǵ� �Լ�
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bgmSource.clip = Resources.Load<AudioClip>($"Sound/{SceneManager.GetActiveScene().name}Bgm"); // �⺻ BGM
        if (bgmSource.isPlaying == false)
            bgmSource.Play();
    }

    public void SetVolume(float volume, Define.SoundType type)
    {
        if(type == Define.SoundType.SFX)
            sfxSource.volume = volume;
        else if(type == Define.SoundType.BGM)
            bgmSource.volume = volume;
    }

}
