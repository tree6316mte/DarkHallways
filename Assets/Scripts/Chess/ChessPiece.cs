using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public ChessTargetPosition targetData; // 목표 위치 데이터
    private bool isHeld = false;

    private void Update()
    {
        if (isHeld)
        {
            // 마우스를 따라 이동 (예제 코드, 필요 시 조정 가능)
            transform.position = GetMouseWorldPosition();

            if (Input.GetMouseButtonDown(0)) // 좌클릭으로 놓기
            {
                PlacePiece();
            }
        }
    }

    public void PickUp()
    {
        isHeld = true;
        Debug.Log(targetData.pieceName + " 주웠음!");
    }

    private void PlacePiece()
    {
        isHeld = false;
        Debug.Log(targetData.pieceName + " 놓음!");
        ChessPuzzleManager.Instance.CheckPlacement();
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
