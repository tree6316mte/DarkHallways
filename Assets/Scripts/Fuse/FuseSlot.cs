using UnityEngine;

public class FuseSlot : MonoBehaviour
{
    public FuseManager fuseManager;
    public bool hasFuse;  // 퓨즈가 있는지 여부
    private Fusee currentFuse;

    // 슬롯에 퓨즈가 있는지 확인하는 속성
    public bool HasFuse
    {
        get { return hasFuse; }
        set { hasFuse = value; }
    }

    public void InsertFuse(Fusee fusee)
    {
        if (!hasFuse)  // 슬롯에 퓨즈가 없으면
        {
            currentFuse = fusee;
            hasFuse = true;  // 퓨즈 삽입
            Debug.Log($"{fusee.fuseName}가 슬롯에 삽입됨.");
            if (fuseManager != null) fuseManager.CheckFuseOrder();
        }
    }

    // 퓨즈를 슬롯에서 제거하는 함수
    public void RemoveFuse()
    {
        if (HasFuse)
        {
            Debug.Log($"{currentFuse.fuseName} 퓨즈가 슬롯에서 제거됨!");
            HasFuse = false;  // 퓨즈가 슬롯에서 제거됨
            currentFuse = null;
        }
    }

    // 현재 슬롯에 올바른 퓨즈가 들어있는지 확인하는 함수
    public bool IsCorrectFuse()
    {
        //return currentFuse != null && currentFuse.fuseColor == correctFuseColor;
        return true;
    }
}
