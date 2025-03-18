using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card System/Card Data")]
public class CardData : ScriptableObject
{
    public int cardID;
    public string cardName;
}