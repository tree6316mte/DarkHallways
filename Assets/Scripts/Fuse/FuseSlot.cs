using UnityEngine;

public class FuseSlot : MonoBehaviour
{
    public InteractiveItem slotData;  // 이 슬롯에 들어갈 퓨즈 정보
    private Item currentFuse;         // 현재 슬롯에 있는 퓨즈

    public bool HasFuse => currentFuse != null;

    public void InsertFuse(Item fuse)
    {
        if (!HasFuse)  // 슬롯이 비어 있을 때만 퓨즈 삽입 가능
        {
            currentFuse = fuse;
            Debug.Log($"{fuse.itemName} 퓨즈가 슬롯에 삽입됨!");
        }
        else
        {
            Debug.Log("슬롯이 이미 차 있습니다!");
        }
    }

    public void RemoveFuse()
    {
        if (HasFuse)
        {
            Debug.Log($"{currentFuse.itemName} 퓨즈가 슬롯에서 제거됨!");
            currentFuse = null;
        }
    }

    public bool IsCorrectFuse()
    {
        return HasFuse && currentFuse.itemCode == slotData.itemCode;
    }
}
