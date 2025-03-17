using UnityEngine;
using System.Collections.Generic;

public class ChessPuzzleManager : MonoBehaviour
{
    public static ChessPuzzleManager Instance;
    public List<ChessPiece> chessPieces;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckPlacement()
    {
        foreach (var piece in chessPieces)
        {
            float distance = Vector3.Distance(piece.transform.position, piece.targetData.targetPosition);
            if (distance > piece.targetData.placementThreshold)
            {
                Debug.Log("배치가 틀림! " + piece.targetData.pieceName);
                return;
            }
        }
        Debug.Log("성공!");
    }
}
