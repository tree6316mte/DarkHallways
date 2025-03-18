using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractiveItem", menuName = "Custom/InteractiveItem", order = 2)]
public class InteractiveItem : ScriptableObject
{
    public string interactiveItemName;
    public int itemCode;
    public Transform camPos;
}
