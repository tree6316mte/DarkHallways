using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.LookDev;


public class MovableObject : PuzzleHandler
{
   
    Camera camera;
    string promptText;
    bool right = false;
    public float movingTime = 2f;
    private bool isMoved = false;
    public Vector3 movePosition;
    Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
        camera = Camera.main;
    }
    private void Update()
    {
        DetectCamera();
        if (!isMoved && Input.GetMouseButtonDown(0)) Interact();
    }
    public override void InteractPuzzle()
    {
        Interact();
    }
    public override string GetDescription()
    {
        DetectCamera();
        return base.GetDescription();
    }
    public void Interact()
    {
        StartCoroutine(MoveCoroutine(right));
        isMoved = true;
    }
    
    private void DetectCamera()
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
        Debug.Log(puzzle.description);
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
