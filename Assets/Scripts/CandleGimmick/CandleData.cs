using UnityEngine;

[CreateAssetMenu(fileName = "NewCandleData", menuName = "ScriptableObjects/CandleData")]
public class CandleData : ScriptableObject
{
    public bool isLit = false; // 불이 붙었는지 여부
    public bool hasBeenLit = false; // 한 번이라도 불이 붙었는지 여부
}
