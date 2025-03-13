using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIController : MonoBehaviour
{
    public void OnClickGameStart()
    {
        UIManager.Instance.ShowPopup(
            title: "게임 시작",
            message: "시작 하시겠습니까?",
            GameStart
        );
    }
    public void OnClickGameQuit()
    {
        UIManager.Instance.ShowPopup(
            title: "종료",
            message: "게임을 종료 하시겠습니까?",
            GameQuit
        );
    }

    private void GameStart()
    {
        Debug.Log("게임시작!");
    }
    private void GameQuit()
    {
        Debug.Log("게임시작!");
    }
}
