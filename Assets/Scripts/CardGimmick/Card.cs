using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData; // ScriptableObject 받아오기
    private Vector3 originalPosition; // 바닥에서 떨어질때 원래 위치로 

    void Start()
    {
        originalPosition = transform.position;
    }

    // 바닥으로 떨어뜨리기
    public void DropToGround()
    {
        transform.position = originalPosition + new Vector3(0, 0.5f, 0);
    }
}
