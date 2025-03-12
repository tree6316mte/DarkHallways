using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public GameObject candle; // 캔들 오브젝트
    private CandleController candleController; // 캔들의 CandleController 스크립트

    public float interactDistance = 3f; // 상호작용 가능한 거리

    void Start()
    {
        // 캔들 오브젝트에서 CandleController 스크립트를 찾기
        candleController = candle.GetComponent<CandleController>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, candle.transform.position) <= interactDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                candleController.LightCandle(); // 라이터로 불을 붙일 때만 불을 켬
            }
        }
    }
}
