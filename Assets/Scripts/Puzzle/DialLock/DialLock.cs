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

    public GameObject drum;

    private void Start()
    {
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
        if (complete)
        {
            isOpen = true;
            drum.SetActive(false );
            gameObject.AddComponent<Rigidbody>();
            Destroy(this, 2f);
        }
        Debug.Log(complete);

    }



    public override void InteractPuzzle()
    {
        base.InteractPuzzle();
        Debug.Log("dial");
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
            drum.SetActive(false);
            EndDial();
        }
            
    }
    public void NextDrum()
    {
        StartCoroutine(MoveDrum(Vector3.left * 40f));
        index++;
    }

    public void PrevDrum()
    {
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

           drum.SetActive(true);
        
    }
}
