using System.Collections.Generic;
using UnityEngine;
using System;


public enum EPieceType
{
    Queen,
    Bishop,
    End
}

[DefaultExecutionOrder(-1)]
public class ChessPuzzleManager : MonoBehaviour
{
    public static ChessPuzzleManager Instance;
    public int length;
    public List<EPieceType> correctAnswer;
    public List<EPieceType> currentAnswer;
    public Transform[] transforms;
    internal int count;
    public Action getKeyAction;
    public GameObject key;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        getKeyAction += GetKey;

        count = 0;
        currentAnswer = new List<EPieceType>(length);
        transforms = new Transform[length];

        SetTransforms();
    }

    public void Initialize()
    {
        count = 0;
        currentAnswer = new List<EPieceType>(length);
        transforms = new Transform[length];
        SetTransforms();
    }

    private void SetTransforms()
    {
        for (int i = 0; i < length; i++)
        {
            if (transform.GetChild(i) != null)
                transforms[i] = transform.GetChild(i);
            else
                Debug.LogWarning("Pivot 갯수가 부족합니다.");
        }
    }

    public void GetKey()
    {
        key.SetActive(true);
    }
}
