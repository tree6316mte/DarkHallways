using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameEscUI : BaseUI
{
    [HideInInspector] public int chaperPrograss = 0;
    [SerializeField] private TextMeshProUGUI clipBoardText;
    [SerializeField] private List<Button> buttonChapters;
    [SerializeField] private Button buttonContinue;
    [SerializeField] private Button buttonOption;
    [SerializeField] private Button buttonGotoMain;
    [SerializeField] private Button buttonQuit;


    /// <summary>
    /// 옵션 초기화
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();

        if (buttonContinue != null)
            buttonContinue.onClick.AddListener(() => OnClickContinue());

        if (buttonOption != null)
            buttonOption.onClick.AddListener(() => OnClickOption());

        if (buttonGotoMain != null)
            buttonGotoMain.onClick.AddListener(() => OnClickGotoMain());

        if (buttonQuit != null)
            buttonQuit.onClick.AddListener(() => OnClickQuit());

        for (int i = 0; i < buttonChapters.Count; i++)
        {
            int index = i;
            buttonChapters[index].onClick.AddListener(() => OnClickChapterInfo(index));
        }
    }

    public void Setup(int chaperPrograss)
    {
        this.chaperPrograss = chaperPrograss;

        for (int i = 0; i < Mathf.Min(this.chaperPrograss, buttonChapters.Count); i++)
        {
            buttonChapters[i].enabled = true;
        }
        for (int i = this.chaperPrograss; i < buttonChapters.Count; i++)
        {
            buttonChapters[i].enabled = false;
        }
    }

    /// <summary>
    /// 계속하기 버튼 동작
    /// </summary>
    private void OnClickContinue()
    {
        OnHide();
    }

    /// <summary>
    /// 설정 버튼 동작
    /// </summary>
    private void OnClickOption()
    {
        UIManager.Instance.ShowOption();
    }

    /// <summary>
    /// 메인메뉴로 돌아가기 버튼 동작
    /// </summary>
    private void OnClickGotoMain()
    {
        SceneManager.LoadScene("PJW_MainScene");
        OnHide();
    }

    /// <summary>
    /// 게임종료 버튼 동작
    /// </summary>
    private void OnClickQuit()
    {
        OnHide();
    }

    /// <summary>
    /// 게임종료 버튼 동작
    /// </summary>
    private void OnClickChapterInfo(int index)
    {
        // OnHide();
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
