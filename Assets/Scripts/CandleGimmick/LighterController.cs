using UnityEngine;

public class LighterController : MonoBehaviour
{
    public LighterData lighterData;  // LighterData를 불러오기 위한 변수
    public GameObject currentItem; // 플레이어가 들고 있는 아이템

    void Update()
    {
        // 라이터를 들고 있을 때만 레이캐스트 발사
        if (currentItem != null && currentItem.CompareTag("Lighter"))
        {
            if (Input.GetMouseButtonDown(0)) // 좌클릭 시 양초에 불을 붙이기
            {
                TryLightCandle();
            }
        }
    }

    private void TryLightCandle()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // 화면에서 마우스 위치로 Ray 발사
        if (Physics.Raycast(ray, out RaycastHit hit, lighterData.interactDistance)) // 레이캐스트 발사 (스크립터블 오브젝트의 값 사용)
        {
            Debug.Log($"Ray가 {hit.collider.name}을 감지함");

            CandleController candle = hit.collider.GetComponent<CandleController>();  // 양초를 찾고
            if (candle != null)
            {
                Debug.Log("CandleController 감지됨! LightCandle() 실행");
                candle.LightCandle();  // 불을 붙임
            }
            else
            {
                Debug.Log("CandleController가 없음!");
            }
        }
        else
        {
            Debug.Log("Ray가 아무것도 감지하지 못함");
        }
    }
}
