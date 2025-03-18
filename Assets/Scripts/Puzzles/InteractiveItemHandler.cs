using UnityEngine;
using UnityEngine.UIElements;

public class InteractiveItemHandler : MonoBehaviour
{
    public InteractiveItem itemInstance;

    private string validStr;

    public void UseItem(ItemHandler usedItem)
    {
        if (usedItem.itemInstance.itemCode == itemInstance.itemCode)
        {
            usedItem.OnUseItem();
            Debug.Log("아이템 사용됨");
        }
        else
            Debug.Log("아이템 거부됨");
    }

    public string ItemValidator(ItemHandler usedItem)
    {
        return validStr = (usedItem.itemInstance.itemCode == itemInstance.itemCode) ? "사용 가능" : "사용 불가능" ;
    }
}
