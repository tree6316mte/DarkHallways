using UnityEngine;

public class FuseManager : MonoBehaviour
{
    public FuseSlot[] slots;  // 배치된 모든 퓨즈 슬롯
    public GameObject door;   // 퍼즐 성공 시 열릴 문

    public void CheckFuseOrder()
    {
        foreach (var slot in slots)
        {
            if (!slot.HasFuse || !slot.IsCorrectFuse())
            {
                Debug.Log("퓨즈 배치가 올바르지 않습니다!");
                return;
            }
        }

        OpenDoor();
    }

    private void OpenDoor()
    {
        Debug.Log("정답! 문이 열립니다!");
        if (door != null)
        {
            door.SetActive(false); // 문을 비활성화 (열림)
        }
    }
}
