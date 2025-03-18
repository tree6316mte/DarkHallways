using UnityEngine;

public class CardInsert : MonoBehaviour
{
    public Transform slotPosition;  // 슬롯 위치
    private bool isMoving = false;
    private float speed = 5f; // 이동 속도

    void Update()
    {
        if (isMoving)
        {
            // Lerp로 부드럽게 이동
            transform.position = Vector3.Lerp(transform.position, slotPosition.position, Time.deltaTime * speed);

            // 일정 거리 안에 들어오면 정지
            if (Vector3.Distance(transform.position, slotPosition.position) < 0.01f)
            {
                transform.position = slotPosition.position;
                isMoving = false;
            }
        }
    }

    // 카드 삽입 시작
    public void InsertCard()
    {
        isMoving = true;
    }
}
