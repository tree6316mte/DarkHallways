using UnityEngine;

public class FuseManager : PuzzleHandler
{
    public FuseSlot[] slots;  // 배치된 모든 퓨즈 슬롯
    public GameObject door;   // 퍼즐 성공 시 열릴 문

    public Water[] waters;  // 배치된 모든 퓨즈 슬롯
    public void CheckFuseOrder()
    {
        foreach (var slot in slots)
        {
            if (!slot.HasFuse || !slot.IsCorrectFuse())
            {
                Debug.Log("퓨즈 배치가 올바르지 않습니다");
                return;
            }
        }

        // 물 작동 멈추기
        foreach (var water in waters)
        {
            water.isDeath = false;
        }

        // 정답 효과음
        InteractPuzzle();
        // OpenDoor();
    }

    // private void OpenDoor()
    // {
    //     Debug.Log("문이 열립니다.");
    //     if (door != null)
    //     {
    //         door.SetActive(false); // 문을 비활성화 (열림)
    //     }
    // }
}
