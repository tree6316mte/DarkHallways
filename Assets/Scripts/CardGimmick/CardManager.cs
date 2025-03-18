using UnityEngine;

public class CardManager : MonoBehaviour
{
    public CardSlot[] slots;

    public void CheckAllSlots()
    {
        foreach (var slot in slots)
        {
            if (slot.currentCard == null || slot.currentCard.cardData.cardID != slot.slotData.slotID)
            {
                Debug.Log("틀렸습니다!");
                return;
            }
        }
        Debug.Log("성공!");
    }
}
