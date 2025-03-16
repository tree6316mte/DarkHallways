using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public CardSlotData slotData; // ScriptableObject로 변경
    public Card currentCard = null;

    public bool InsertCard(Card card)
    {
        if (card == null) // 카드가 null일 때 처리
        {
            Debug.LogError("카드가 null입니다!");
            return false;
        }

        if (currentCard == null && card.cardData.cardID == slotData.slotID) // 정답 확인
        {
            card.transform.position = transform.position;
            card.transform.rotation = transform.rotation;
            currentCard = card;
            return true;
        }
        return false;
    }

    public Card RemoveCard()
    {
        if (currentCard != null)
        {
            Card temp = currentCard;
            currentCard = null;
            return temp;
        }
        return null;
    }
}
