using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTrap : PuzzleHandler
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
            Debug.Log("DIE");
    }
}
