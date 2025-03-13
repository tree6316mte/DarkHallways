using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 죽었는지 처리와 아이템 상황관리하는 클래스
public class Player : MonoBehaviour
{
    private bool isDead;
    public Item hasItem;

    private void DisplayHasItem()
    {
        string str = (hasItem != null) ? "가진 아이템 : " + hasItem.itemName : "비어있음";
        Debug.Log($"{str}");
    }

    public void GetItem(ItemHandler newItem)
    {
        Debug.Log("호출 GetItem");
        hasItem = newItem.itemInstance;
        Destroy(newItem.gameObject);
    }
}
