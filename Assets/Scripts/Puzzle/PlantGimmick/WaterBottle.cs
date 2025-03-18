using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    private GameObject water;
    public bool isFull; //물이 있는지
    // Start is called before the first frame update
    void Start()
    {
        water = transform.GetChild(0).GetChild(0).gameObject;
        water.SetActive(false);
    }

    private void InteractWater() // 물웅덩이와 상호작용
    {
        isFull = true;
        water.SetActive(true);
    }
    
}
