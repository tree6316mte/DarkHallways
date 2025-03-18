using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            //플레이어 사망
            SoundManager.Instance.PlaySFX("Electric_Water");
        }
    }
}
