using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
            Debug.Log("DIE");
    }
}
