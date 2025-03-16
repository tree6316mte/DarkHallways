using UnityEngine;

[CreateAssetMenu(fileName = "NewSlot", menuName = "Card System/Card Slot Data")]
public class CardSlotData : ScriptableObject
{
    public int slotID;
    public CardData correctCard; // 이 슬롯에 들어갈 올바른 카드
}
