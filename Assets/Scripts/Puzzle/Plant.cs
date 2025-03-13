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
        //TODO. 플레이어가 들고 있는 오브젝트가 물병인지 확인하고 함수 실행
    }
    public void WaterPlant()
    {
        if (!isWatered)
        {
            // 물 주는 사운드
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
