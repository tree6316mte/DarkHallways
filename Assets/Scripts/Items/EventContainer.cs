using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 획득, 사용 이벤트들이 저장됨
public class EventContainer : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    public void GetFlash()
    {
        // 플래시 습득시 호출
        Debug.Log("GetFlash 호출됨");
        player.isGetFlash = true;
        player.hasItem = null;
    }
}
