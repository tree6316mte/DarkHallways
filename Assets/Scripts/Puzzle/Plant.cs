using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public bool isWatered = false;
    public float growthDuration = 2f;
    public Transform palm;
    private Vector3 origin;
    private Vector3 targetScale;

    private void Start()
    {
        origin = palm.localPosition;
        targetScale = new Vector3(palm.localPosition.x, -1f, palm.localPosition.z);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) WaterPlant();
    }
    public void WaterPlant()
    {
        if (!isWatered)
        {
            isWatered = true;
            StartCoroutine(WateringPlant());
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        Debug.Log("정답");
    }

    private IEnumerator WateringPlant()
    {
        float elapsed = 0f;
        while(elapsed < growthDuration)
        {
            Debug.Log(palm.localPosition);
            palm.localPosition = Vector3.Lerp(origin, targetScale, elapsed / growthDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        palm.localPosition = targetScale;
    }
}
