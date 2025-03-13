using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Item itemInstance;

    public void UseItem(InteractiveItem interactiveItem)
    {
        Debug.Log($"UsedItemCode : {itemInstance.itemCode}, InteractiveItemCode : {interactiveItem.itemCode}" + "\n" +
            $"isEqual? -> {(itemInstance.itemCode == interactiveItem.itemCode)}");

        if (itemInstance.itemCode == interactiveItem.itemCode)
        {
            // 사용
            Debug.Log("사용 가능");
        }
    }

    public string GetInfoText(RaycastHit hit)
    {
        if (hit.collider.GetComponent<ItemHandler>())
        {
            return GetItemInfo();
        }
        return string.Empty;
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
