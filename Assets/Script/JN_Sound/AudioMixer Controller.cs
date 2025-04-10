using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer m_AudioMixer;
    [SerializeField] private Slider m_MusicMasterSlider;
    [SerializeField] private Slider m_MusicBGMSlider;
    [SerializeField] private Slider m_MusicSFXSlider;

    private void Awake()
    {
        m_MusicMasterSlider.value = PlayerPrefs.GetFloat("MasterVolume",0.5f);
        m_MusicBGMSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        m_MusicSFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        m_MusicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        m_MusicBGMSlider.onValueChanged.AddListener(SetBGMVolume);
        m_MusicSFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Start()
    {
        SetMasterVolume(m_MusicMasterSlider.value);
        SetBGMVolume(m_MusicBGMSlider.value);
        SetSFXVolume(m_MusicSFXSlider.value);
    }

    public void SetMasterVolume(float value)
    {
        m_AudioMixer.SetFloat("Master", Mathf.Approximately(value, 0f) ? -80f : Mathf.Log10(value) * 20f);
        PlayerPrefs.SetFloat("MasterVolume", value);
        PlayerPrefs.Save();
    }

    public void SetBGMVolume(float value)
    {
        m_AudioMixer.SetFloat("BGM", Mathf.Approximately(value, 0f) ? -80f : Mathf.Log10(value) * 20f);
        PlayerPrefs.SetFloat("BGMVolume", value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        m_AudioMixer.SetFloat("SFX", Mathf.Approximately(value, 0f) ? -80f : Mathf.Log10(value) * 20f);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}
