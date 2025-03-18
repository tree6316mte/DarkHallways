using UnityEngine;

[CreateAssetMenu(fileName = "NewChessTarget", menuName = "Chess/TargetPosition")]
public class ChessTargetPosition : ScriptableObject
{
    public string pieceName; // "Bishop1", "Queen", "Bishop2"
    public Vector3 targetPosition; // 월드 좌표로 저장
    public float placementThreshold = 0.5f; // 허용 오차
}
