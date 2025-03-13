using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.LookDev;

public interface IInteractable
{
    public string GetPromptText();
    public void Interact();
}
public class MovableObject : MonoBehaviour, IInteractable
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
        DetectMousePosition();
        if (!isMoved && Input.GetMouseButtonDown(0)) Interact();
    }
    public string GetPromptText()
    {
        return promptText;
    }

    public void Interact()
    {
        StartCoroutine(MoveCoroutine(right));
        isMoved = true;
    }
    //TODO. Player에 따라 수정
    private void DetectMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y,camera.nearClipPlane));

        float objectCenterX = transform.position.x;
        float mouseX = worldMousePosition.x;

        if (mouseX < objectCenterX)
        {
            promptText = "왼쪽으로 밀기";
            right = false;
        }
        else if (mouseX > objectCenterX)
        {
            promptText = "오른쪽으로 밀기";
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
