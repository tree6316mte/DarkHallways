using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.LookDev;

public enum Direction
{
    Right,
    Left,
    Inter
}

public class MovableObject : PuzzleHandler
{
   
    Camera camera;
    string promptText;
    bool right = false;
    public Direction direction;
    public float movingTime = 2f;
    private bool isMoved = false;
    public Vector3 movePosition;
    Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
        camera = Camera.main;
    }


    public override void InteractPuzzle()
    {
        Interact();
        Destroy(this, 2f);
    }
    public override string GetDescription()
    {
        DetectCamera();
        return base.GetDescription();
    }
    public void Interact()
    {
        SoundManager.Instance.PlaySFX("MoveObject");
        StartCoroutine(MoveCoroutine(right));
        isMoved = true;

    }
    
    private void DetectCamera()
    {
        if (direction == Direction.Inter)
        {
            Transform cameraTransform = camera.transform;
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 toObject = (transform.position - cameraTransform.position).normalized;

            float dotProduct = Vector3.Dot(cameraTransform.right, toObject);
            if (dotProduct > 0)
            {
                puzzle.description = "왼쪽으로 밀기";
                right = false;
            }
            else
            {
                puzzle.description = "오른쪽으로 밀기";
                right = true;
            }
        }
        else if(direction == Direction.Left)
        {
            puzzle.description = "";
            right = false;
        }
        else if(direction == Direction.Right)
        {
            puzzle.description = "";
            right = true;
        }
    }

    private IEnumerator MoveCoroutine(bool right)
    {
        float elasped = 0f;

        while(elasped < movingTime)
        {
            if(right)
                transform.position = Vector3.Lerp(startPosition, startPosition + movePosition, elasped / movingTime);
            else
            {
                 transform.position = Vector3.Lerp(startPosition, startPosition - movePosition, elasped / movingTime * movingTime);
            }

            elasped += Time.deltaTime;
            yield return null;
        }

        if(right) transform.position = startPosition + movePosition;
        else transform.position = startPosition - movePosition;
    }
}
