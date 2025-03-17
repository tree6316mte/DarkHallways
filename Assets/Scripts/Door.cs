using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PuzzleHandler locker; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (locker.isOpen) Open();
    }

    public void Open()
    {
        StartCoroutine(OpenDoor());
    }
    private IEnumerator OpenDoor()
    {
        float elapsed = 0f;

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, -120, 0);
        while (elapsed < 2f)
        {
            elapsed += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsed / 2);
            yield return null;
        }
        transform.rotation = targetRotation;
    }
}
