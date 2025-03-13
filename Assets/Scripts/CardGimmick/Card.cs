using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardID; // 카드의 고유 ID
    private Vector3 originalPosition; // 바닥에 떨어질 때 원래 위치로 이동

    void Start()
    {
        originalPosition = transform.position;
    }

    // 바닥으로 떨어뜨리기
    public void DropToGround()
    {
        transform.position = originalPosition + new Vector3(0, 0.5f, 0); // 살짝 위에서 떨어지도록
    }
}
