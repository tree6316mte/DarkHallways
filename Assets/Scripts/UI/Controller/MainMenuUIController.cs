using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    public string gameSceneName;
    public string endingSceneName;
    public void OnClickGameStart()
    {
        UIManager.Instance.ShowPopup(
            title: "게임 시작",
            message: "시작 하시겠습니까?",
            GameStart
        );
    }

    public void OnClickGameContinue()
    {
        UIManager.Instance.ShowPopup(
            title: "게임 계속 하기",
            message: "저장된 지점에서 부터 게임을 시작 하시겠습니까?",
            GameStart
        );
    }

    public void OnClickCredit()
    {
        SceneManager.LoadScene(endingSceneName);
    }


    public void OnClickGameQuit()
    {
        UIManager.Instance.ShowPopup(
            title: "종료",
            message: "게임을 종료 하시겠습니까?",
            GameQuit
        );
    }
    public void OnClickOption()
    {
        UIManager.Instance.ShowOption();
    }

    private void GameStart()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    private void GameContinue()
    {
        // SceneManager.LoadScene(endingSceneName);
        Debug.Log("계속하기");
    }

    private void GameQuit()
    {
        Debug.Log("게임종료!");
    }
}
