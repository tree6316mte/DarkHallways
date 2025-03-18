using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform holdPosition;  // 플레이어가 카드를 들고 있을 위치
    private Card heldCard = null;   // 현재 플레이어가 들고 있는 카드

    void OnCollisionEnter(Collision collision)
    {
        // 물웅덩이나 전선에 충돌했을 때
        if (collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("Wire"))
        {
            Debug.Log("죽었다!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 물웅덩이나 전선에 충돌했을 때
        if (other.CompareTag("Water") || other.CompareTag("Wire"))
        {
            Debug.Log("죽었다!");
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 좌클릭 시도
        {
            Debug.Log("좌클릭 감지됨!"); // 클릭 감지 로그
            TryInsertOrRemoveCard(); // 카드 삽입/삭제 함수 호출
        }

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
        if (heldCard == null) // 카드가 null이면 함수 종료
        {
            Debug.LogError("카드가 없습니다!");
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            CardSlot slot = hit.collider.GetComponent<CardSlot>();

            if (slot != null)
            {
                bool inserted = slot.InsertCard(heldCard);
                if (inserted)
                {
                    Debug.Log("카드 삽입 성공");
                }
                else
                {
                    Debug.LogError("카드 삽입 실패");
                }
            }
            else
            {
                Debug.LogError("Raycast가 슬롯을 감지하지 못함.");
            }
        }
        else
        {
            Debug.LogError("Raycast가 아무것도 감지하지 못함.");
        }
    }

}
