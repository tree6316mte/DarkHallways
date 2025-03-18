using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Haptics;
using UnityEngine.UI;


public class DialLock : PuzzleHandler
{
    public NumbersDrum[] drums;
    public int[] answers;
    public bool isDialOpen;
    public int index = 0;


    private bool complete = false;

    public float moveSpeed = 2f;
    private Vector3 originPos;
    public GameObject drum;
    public Transform cameraPos;

    private void Start()
    {
        originPos = drum.transform.position;
        index = 0;
        drum.SetActive(false);
    }
    private void Update()
    {
        if (drum.activeSelf) InputDial();
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
        complete = true;
        for (int i = 0; i < drums.Length; i++)
        {
            Debug.Log(drums[i].CurCount);
            if (drums[i].CurCount != answers[i])
            {
                complete = false;
                return;
            }
        }
    }

    public void EndDial()
    {
        CheckCode();
        if (complete)
        {
            isOpen = true;
            drum.SetActive(false );
            SoundManager.Instance.PlaySFX("DialClear");
            gameObject.AddComponent<Rigidbody>();
            Destroy(this, 2f);
        }
        Debug.Log(complete);
        isDialOpen = false;

    }



    public override void InteractPuzzle()
    {
        base.InteractPuzzle();
        OpenDial();
    }

    public void InputDial()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            drums[index].UpArrow();
        if (Input.GetKeyDown(KeyCode.DownArrow))  
            drums[index].DownArrow();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(index != 0) PrevDrum();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(index != 2) NextDrum();
        }
            
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InitDrum();
            drum.SetActive(false);
            EndDial();
        }
            
    }
    public void NextDrum()
    {
        SoundManager.Instance.PlaySFX("DialSwitch");
        StartCoroutine(MoveDrum(Vector3.left * 40f));
        index++;
    }

    public void PrevDrum()
    {
        SoundManager.Instance.PlaySFX("DialSwitch");
        StartCoroutine(MoveDrum(Vector3.right * 40f));
        index--;
    }
    IEnumerator MoveDrum(Vector3 targetPosition)
    {
        Vector3 startPosition = drum.transform.position;
        Vector3 endPosition = startPosition + targetPosition;
        float length = Vector3.Distance(startPosition, endPosition);
        float startTime = Time.time;

        while (Vector3.Distance(drum.transform.position, endPosition) > 0.1f)
        {
            float distance = (Time.time - startTime) * moveSpeed;

            drum.transform.position = Vector3.Lerp(startPosition, endPosition, distance / length);
            yield return null;
        }

        drum.transform.position = endPosition;
    }

    public void OpenDial()
    {
        index = 0;
        drum.SetActive(true);
        isDialOpen = true;
    }

    public void InitDrum()
    {
        index = 0;
        drum.transform.position = originPos;
    }
}
