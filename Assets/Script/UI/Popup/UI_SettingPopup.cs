using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_SettingPopup : UI_Popup
{
    enum Sliders
    {
        BGMSlider,
        SFXSlider
    }
    enum Buttons
    {
        PointButton,
        GoStartButton
    }
    public override void Init()
    {
        base.Init();

        Bind<Slider>(typeof(Sliders));
        Bind<Button>(typeof(Buttons));

        Get<Button>((int)Buttons.PointButton).onClick.AddListener(OnPointButtonClicked);
        Button goStartButton =  Get<Button>((int)Buttons.GoStartButton);
        goStartButton.onClick.AddListener(OnGoMainButtonClicked);
        if (SceneManager.GetActiveScene().name == "Start") // startScene에서는 Start로 돌아가는 함수 불필요
            goStartButton.gameObject.SetActive(false);


        Slider bgmSlider = Get<Slider>((int)Sliders.BGMSlider);
        bgmSlider.onValueChanged.AddListener(OnBgmSliderValueChange);
        bgmSlider.value = SoundManager.instance.BgmVolume;
        Slider sfxSlider = Get<Slider>((int)Sliders.SFXSlider);
        sfxSlider.onValueChanged.AddListener(OnSFXSliderValueChange);
        sfxSlider.value = SoundManager.instance.SfxVolume;


    }


    protected void OnPointButtonClicked()
    {
        UIManager.instance.ClosePopupUI();
    }
    protected void OnGoMainButtonClicked()
    {
        SceneManager.LoadScene("Start");
    }
    private void OnBgmSliderValueChange(float value)
    {
        SoundManager.instance.SetVolume(value,Define.SoundType.BGM);
    }
    private void OnSFXSliderValueChange(float value)
    {
        SoundManager.instance.SetVolume(value, Define.SoundType.SFX);
    }
}
