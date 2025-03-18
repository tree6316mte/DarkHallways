using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public ChessTargetPosition targetData; // 목표 위치 데이터

    public void PickUp()
    {
        Debug.Log(targetData.pieceName + " 주웠음!");
    }

    public void PlacePiece()
    {
        Debug.Log(targetData.pieceName + " 놓음!");

        // 목표 위치와의 차이 비교
        float distance = Vector3.Distance(transform.position, targetData.targetPosition);
        if (distance <= targetData.placementThreshold)
        {
            transform.position = targetData.targetPosition; // 목표 위치에 정확히 배치
            ChessPuzzleManager.Instance.CheckPlacement(); // 배치 확인
        }
        else
        {
            Debug.Log("잘못된 위치에 배치됨!"); // 목표 위치가 아니라면 경고
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point + Vector3.up * 0.1f; // 살짝 띄워서 배치
        }
        return transform.position;
    }
}
