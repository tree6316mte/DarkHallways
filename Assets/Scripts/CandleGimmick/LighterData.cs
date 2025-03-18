using UnityEngine;

[CreateAssetMenu(fileName = "NewLighterData", menuName = "ScriptableObjects/LighterData")]
public class LighterData : ScriptableObject
{
    public float interactDistance = 3f; // 상호작용 거리
    public bool isHeld = false; // 플레이어가 라이터를 들고 있는지 여부
}