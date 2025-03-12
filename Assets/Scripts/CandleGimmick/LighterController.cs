using UnityEngine;

public class LighterController : MonoBehaviour
{
    public GameObject candle;  // 캔들 오브젝트
    private CandleController candleController;  // 캔들의 CandleController 스크립트

    [SerializeField]  // private로 선언하면서 인스펙터에 보이도록 설정
    private float interactDistance = 3f;  // 상호작용 가능한 거리

    void Start()
    {
        // 캔들 오브젝트에서 CandleController 스크립트를 찾기
        candleController = candle.GetComponent<CandleController>();
    }

    void Update()
    {
        // 라이터가 캔들에 가까워지면 상호작용 가능
        if (Vector3.Distance(transform.position, candle.transform.position) <= interactDistance)
        {
            if (Input.GetKeyDown(KeyCode.F))  // F 키로 불을 붙임
            {
                // 라이터로 불을 붙일 때만 불을 켬
                candleController.LightCandle();
            }
        }
    }
}
