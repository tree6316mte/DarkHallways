using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public GameObject candle; // ĵ�� ������Ʈ
    private CandleController candleController; // ĵ���� CandleController ��ũ��Ʈ

    public float interactDistance = 3f; // ��ȣ�ۿ� ������ �Ÿ�

    void Start()
    {
        // ĵ�� ������Ʈ���� CandleController ��ũ��Ʈ�� ã��
        candleController = candle.GetComponent<CandleController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
