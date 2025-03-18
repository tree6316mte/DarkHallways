using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isShutter; // 문인지 셔터인지
    public PuzzleHandler locker;
    public bool direction; // true면 왼쪽, false면 오른쪽
    private bool isOpened; // 열렸는지

    public Collider collider;

    void Update()
    {
        if (locker != null)
            if (locker.isOpen) Open();
    }

    public void Open()
    {
        if (!isOpened)
        {
            if (!isShutter)
            {
                StartCoroutine(OpenDoor(direction));
                SoundManager.Instance.PlaySFX("DoorOpen");
            }
            else
            {
                StartCoroutine(OpenShutter());
                SoundManager.Instance.PlaySFX("ShutterOpen");
            }
            isOpened = true;
        }
    }
    private IEnumerator OpenDoor(bool direction)
    {
        float elapsed = 0f;
        Quaternion targetRotation;
        Quaternion startRotation = transform.rotation;
        if (!direction)
        {
            targetRotation = Quaternion.Euler(0, -120, 0);
        }
        else targetRotation = Quaternion.Euler(0, -120, 0);
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
        Vector3 target = start + new Vector3(0, 4, 0);
        while (elapsed < 2f)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, target, elapsed / 2);
            yield return null;
        }
        transform.position = target;
        if (collider != null) collider.enabled = false;
    }



}
