using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public int slotID; // 슬롯의 고유 ID (올바른 카드 ID와 일치해야 함)
    public Card currentCard = null; // 현재 슬롯에 들어간 카드

    // 카드 넣기
    public bool InsertCard(Card card)
    {
        if (currentCard == null && card.cardID == slotID) // 정답 확인
        {
            card.transform.position = transform.position;
            card.transform.rotation = transform.rotation;
            currentCard = card;
            return true; // 성공적으로 삽입
        }
        return false; // 틀린 카드이거나 슬롯이 비어있지 않음
    }

    // 카드 빼기
    public Card RemoveCard()
    {
        if (currentCard != null)
        {
            Card temp = currentCard;
            currentCard = null;
            return temp; // 슬롯에서 카드를 빼서 반환
        }
        return null;
    }
}
