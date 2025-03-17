using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 사용 이벤트들을 명시함
public class EventContainer : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void GetFuctionFromItemCode(ItemHandler itemHandler)
    {
        switch(itemHandler.itemCode)
        {
            case 0:
                itemHandler.useItemEvent += DebugItemCode;
                break;
            case 1:
                itemHandler.useItemEvent += UnLock;
                break;
            default:
                Debug.Log("할당된 이벤트가 없습니다.");
                break;
        }
    }

    public void DebugItemCode(ItemHandler itemHandler)
    {
        Debug.Log($"아이템 코드 : {itemHandler.itemCode}");
    }

    public void UnLock(ItemHandler itemHandler)
    {
        // 문이 열림
        // 자물쇠가 중력 영향을 받게 됨
    }
}
