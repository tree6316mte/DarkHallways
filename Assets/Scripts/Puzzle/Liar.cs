using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Liar : MonoBehaviour
{

    private void Start()
    {
        SetChildrenActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
           SetChildrenActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            SetChildrenActive(false);
        }
    }

    private void SetChildrenActive(bool isActive)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }
}
