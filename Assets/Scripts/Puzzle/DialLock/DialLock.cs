using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialLock : PuzzleHandler
{
    public NumbersDrum[] drums;
    public int[] answers;

    public int index = 0;


    private bool complete = false;

    public float moveSpeed = 2f;

    public Action ChangeIndex;
    UI_DialLock ui;
    private void Start()
    {
        index = 0;
        if(ui == null) ui = FindObjectOfType<UI_DialLock>();
    }

    public void SetAnswer(int[] answer) // 각 다이얼 정답 지정
    {
        for (int i = 0; i < drums.Length; i++)
        {
            if( i < answers.Length)
            {
                drums[i].answer = answer[i];
            }
        }
    }

    public void CheckCode() // 정답 체크
    {
        complete = false;
        for (int i = 0; i < drums.Length; i++)
        {
            if (!drums[i].IsCorrect) return;
            else complete = true;
        }
    }

    public void EndDial()
    {
        CheckCode();
        InteractPuzzle();
        Debug.Log(complete);
    }

    public override void InteractPuzzle()
    {
        base.InteractPuzzle();
        ui.OpenDial();
    }

}
