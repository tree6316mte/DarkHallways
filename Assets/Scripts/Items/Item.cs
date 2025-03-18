using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item", menuName = "Custom/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int itemCode;
    public bool isThereCam;
}
