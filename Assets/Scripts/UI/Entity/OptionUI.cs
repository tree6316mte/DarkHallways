using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class OptionUI : BaseUI
{

    [SerializeField] private InputFieldSlider bgmSlider;
    [SerializeField] private InputFieldSlider sfxSlider;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;

    /// <summary>
    /// 옵션 초기화
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();

        if (confirmButton != null)
            confirmButton.onClick.AddListener(() => Confirm());

        if (cancelButton != null)
            cancelButton.onClick.AddListener(() => Cancel());
    }

    public void Setup()
    {
        bgmSlider.Setup((value) =>
        {
            SetBGM(value);
        });

        sfxSlider.Setup((value) =>
        {
            SetSFX(value);
        });

        int bgmVolume = PlayerPrefs.GetInt(SoundManager.Instance.bgmHash, 100);
        int sfxVolume = PlayerPrefs.GetInt(SoundManager.Instance.sfxHash, 100);
        Debug.Log(bgmVolume);
        Debug.Log(sfxVolume);


        SetBGM(bgmVolume);
        SetSFX(sfxVolume);
        bgmSlider.SetValue(bgmVolume);
        sfxSlider.SetValue(sfxVolume);
    }

    /// <summary>
    /// 확인 버튼 동작
    /// </summary>
    private void Confirm()
    {
        SetBGM(bgmSlider.GetValue());
        SetSFX(sfxSlider.GetValue());
        OnHide();
    }

    /// <summary>
    /// 취소 버튼 동작
    /// </summary>
    private void Cancel()
    {
        OnHide();
    }

    private void SetBGM(int value)
    {
        PlayerPrefs.SetInt(SoundManager.Instance.bgmHash, value);
        SoundManager.Instance.bgmPlayer.volume = value / 100f;
    }
    private void SetSFX(int value)
    {
        PlayerPrefs.SetInt(SoundManager.Instance.sfxHash, value);
        SoundManager.Instance.sfxPlayer.volume = value / 100f;
    }
}
