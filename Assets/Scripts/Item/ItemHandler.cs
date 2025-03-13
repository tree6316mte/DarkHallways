using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    internal Item itemInstance;

    public void UseItem()
    {
        /* 
         * Usable Object(퍼즐)와 Item이 있고
         * Usable Object에 Item에 특정한 숫자를 매김
         * 레이캐스트 히트된 Usable Object와 Item의 Code가 같으면 UseItem이 사용됨
         */

        Debug.Log($"UsedItemCode : {itemInstance.itemCode}");
    }

    public string GetItemName()
    {
        return itemInstance.itemName;
    }

    public string GetItemDescription()
    {
        return itemInstance.itemDescription;
    }

    public string GetItemInfo()
    {
        return $"{itemInstance.itemName}\n{itemInstance.itemDescription}";
    }
}
