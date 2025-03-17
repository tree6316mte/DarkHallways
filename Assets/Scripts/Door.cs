using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isShutter; // 문인지 셔터인지
    public PuzzleHandler locker; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (locker != null)
            if (locker.isOpen) Open();
    }

    public void Open()
    {
        if (!isShutter)
            StartCoroutine(OpenDoor());
        else StartCoroutine(OpenShutter());
    }
    private IEnumerator OpenDoor()
    {
        float elapsed = 0f;

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 120, 0);
        while (elapsed < 2f)
        {
            elapsed += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsed / 2);
            yield return null;
        }
        transform.rotation = targetRotation;
    }

    private IEnumerator OpenShutter()
    {
        float elapsed = 0f;

        Vector3 start = transform.position;
        Vector3 target = start + new Vector3(0, 5, 0);
        while (elapsed < 2f)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, target, elapsed / 2);
            yield return null;
        }
        transform.position = target;
    }
    
}
