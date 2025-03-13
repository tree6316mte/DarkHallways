using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Item itemInstance;

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
