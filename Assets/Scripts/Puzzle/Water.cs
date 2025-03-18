using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private Transform savePoint;
    public bool isDeath = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && isDeath)
        {
            other.transform.position = savePoint.position;
            SoundManager.Instance.PlaySFX("Electric_Water");
        }
    }
}
