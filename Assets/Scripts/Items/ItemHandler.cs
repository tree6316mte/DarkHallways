using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public Item itemInstance;
    public PuzzleHandler puzzleHandler;
    internal int itemCode;
    public event Action<ItemHandler> useItemEvent;
    private EventContainer eventContainer;
    public GameObject camPos;

    private void Awake()
    {
        itemCode = itemInstance.itemCode;
    }

    private void Start()
    {
        eventContainer = FindFirstObjectByType<EventContainer>();
        eventContainer.GetFuctionFromItemCode(this);
    }

    public string GetInfoText(RaycastHit hit)
    {
        if (hit.collider.GetComponent<ItemHandler>())
        {
            return GetItemInfo();
        }
        return string.Empty;
    }

    public void OnUseItem()
    {
        useItemEvent?.Invoke(this);
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
