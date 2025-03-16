using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform holdPosition;  // 플레이어가 카드를 들고 있을 위치
    private Card heldCard = null;   // 현재 플레이어가 들고 있는 카드

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickupCard();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (heldCard != null)
                TryInsertOrRemoveCard();
        }
    }

    void PickupCard()
    {
        if (heldCard == null) // 이미 들고 있는 카드가 없을 때만 줍기 가능
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                Card card = hit.collider.GetComponent<Card>();
                if (card != null)
                {
                    heldCard = card;
                    heldCard.transform.position = holdPosition.position;
                    heldCard.transform.parent = holdPosition;
                }
            }
        }
    }

    void TryInsertOrRemoveCard()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            CardSlot slot = hit.collider.GetComponent<CardSlot>();

            if (slot != null)
            {
                if (slot.currentCard == null) // 슬롯이 비어 있으면 삽입
                {
                    if (slot.InsertCard(heldCard))
                    {
                        heldCard.transform.parent = null;
                        heldCard = null;
                    }
                }
                else if (slot.currentCard != null) // 슬롯에 카드가 있으면 빼기
                {
                    heldCard = slot.RemoveCard();
                    heldCard.transform.position = holdPosition.position;
                    heldCard.transform.parent = holdPosition;
                }
            }
        }
    }
}
