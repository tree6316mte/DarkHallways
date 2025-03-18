using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadLock : PuzzleHandler
{
    private string curInput; // 입력된 숫자
    public int maxLength; // 자릿수
    public int answerCode; // 정답
    public GameObject door;

    [Header("텍스트")]
    public string correctText = "OPEN";
    public string denyText = "DENIED";

    public Renderer panelMesh;
    public TextMeshProUGUI inputText;
    private float screenIntensity = 2.5f;

    [Header("화면 색")]
    public Color screenNormalColor = new Color(0.98f, 0.50f, 0.032f, 1f);
    public Color screenDeniedColor = new Color(1f, 0f, 0f, 1f); 
    public Color screenGrantedColor = new Color(0f, 0.62f, 0.07f); 

    private bool complete = false;
    private bool displaying = false;
    private void Awake()
    {
        ClearInput();
        panelMesh.material.SetVector("_EmissionColor", screenNormalColor);
    }

    public void AddInput(string input)
    {
        SoundManager.Instance.PlaySFX("keypadClick");
        if (displaying || complete) return;
        switch (input)
        {
            case "enter":
                CheckCode();
                break;
            default:
                if (curInput == null && curInput.Length == maxLength) return;
                Debug.Log(input);
                curInput += input;
                Debug.Log(curInput);
                inputText.text = curInput;
                break;
        }
    }

    public void CheckCode()
    {
        if(int.TryParse(curInput, out int curInputNum))
        {
            complete = curInputNum == answerCode;
            if (!displaying)
            {
                StartCoroutine(DisplayResult(complete));
            }
        }
    }

    public void ClearInput()
    {
        curInput = "";
        inputText.text = curInput;
    }

    public void Correct() // 정답 시
    {
        inputText.text = correctText;
        panelMesh.material.SetVector("_EmissionColor", screenGrantedColor * screenIntensity);
        SoundManager.Instance.PlaySFX("keypadGranted");
        InteractPuzzle();    
    }

    public void Denied() // 오답 시
    {
        inputText.text = denyText;
        panelMesh.material.SetVector("_EmissionColor", screenDeniedColor * screenIntensity);
        SoundManager.Instance.PlaySFX("keypadDeniedd");
    }

    private IEnumerator DisplayResult(bool ok) // 조작 중
    {
        displaying = true;

        if (ok) Correct();
        else Denied();

        yield return new WaitForSeconds(1f);

        if (ok) yield break;
        displaying = false;
        ClearInput();
        panelMesh.material.SetVector("_EmissionColor", screenNormalColor * screenIntensity);
    }



}
