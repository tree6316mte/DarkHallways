using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItemHandler : MonoBehaviour
{
    public InteractiveItem interactiveItem;

    private string validStr;

    public void UseItem(Item usedItem)
    {
        if (usedItem.itemCode == interactiveItem.itemCode)
            Debug.Log("아이템 사용됨");
        else
            Debug.Log("아이템 거부됨");
    }

    public string ItemValidator(Item usedItem)
    {
        return validStr = (usedItem.itemCode == interactiveItem.itemCode) ? "사용 가능" : "사용 불가능" ;
    }
}
