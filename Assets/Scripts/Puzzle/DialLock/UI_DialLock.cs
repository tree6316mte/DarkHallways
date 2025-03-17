using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DialLock : MonoBehaviour
{
    public Button up;
    public Button down;
    public Button next;
    public Button prev;
    public Button check;
    public GameObject drum;

    private int previousIndex;

    public DialLock dialLock;
    private void Start()
    {
        previousIndex = dialLock.index;

        drum.SetActive(false);
        check.gameObject.SetActive(false);
        SetButtonListener(dialLock.index);
        InitUI();
    }
    private void Update()
    {
        OpenDial();

        if (dialLock.index != previousIndex)
        {
            UpdateArrow();
            SetButtonListener(dialLock.index);
            previousIndex = dialLock.index;
        }
    }

    public void InitUI()
    {
        up.gameObject.SetActive(false);
        down.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
        prev.gameObject.SetActive(false);
    }
    public void OpenDial()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            drum.SetActive(true);
            check.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
            UpdateArrow();
        }
    }
    public void NextDrum()
    {
        StartCoroutine(MoveDrum(Vector3.left * 40f));
        dialLock.index++;
    }

    public void PrevDrum()
    {
        StartCoroutine(MoveDrum(Vector3.right * 40f));
        dialLock.index--;
    }

    IEnumerator MoveDrum(Vector3 targetPosition)
    {
        Vector3 startPosition = drum.transform.position;
        Vector3 endPosition = startPosition + targetPosition;
        float length = Vector3.Distance(startPosition, endPosition);
        float startTime = Time.time;

        while (Vector3.Distance(drum.transform.position, endPosition) > 0.1f)
        {
            float distance = (Time.time - startTime) * dialLock.moveSpeed;

            drum.transform.position = Vector3.Lerp(startPosition, endPosition, distance / length);
            yield return null;
        }

        drum.transform.position = endPosition;
    }
    private void UpdateArrow()
    {
        if (dialLock.index == 0)
        {
            prev.gameObject.SetActive(false);
            next.gameObject.SetActive(true);
        }
        else if (dialLock.index == 1)
        {
            prev.gameObject.SetActive(true);
            next.gameObject.SetActive(true);
        }
        else if (dialLock.index == 2)
        {
            next.gameObject.SetActive(false);
        }
    }
    public void SetButtonListener(int index)
    {
        up.onClick.RemoveListener(dialLock.drums[previousIndex].UpArrow);
        down.onClick.RemoveListener(dialLock.drums[previousIndex].DownArrow);

        up.onClick.AddListener(dialLock.drums[index].UpArrow);
        down.onClick.AddListener(dialLock.drums[index].DownArrow);
    }
    public void End()
    {
        drum.gameObject.SetActive(false);
        check.gameObject.SetActive(false);
        dialLock.EndDial();
        InitUI();
    }

}
