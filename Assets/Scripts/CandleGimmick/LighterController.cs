using UnityEngine;

public class LighterController : MonoBehaviour
{
    public GameObject candle;  // ĵ�� ������Ʈ
    private CandleController candleController;  // ĵ���� CandleController ��ũ��Ʈ

    [SerializeField]  // private�� �����ϸ鼭 �ν����Ϳ� ���̵��� ����
    private float interactDistance = 3f;  // ��ȣ�ۿ� ������ �Ÿ�

    void Start()
    {
        // ĵ�� ������Ʈ���� CandleController ��ũ��Ʈ�� ã��
        candleController = candle.GetComponent<CandleController>();
    }

    void Update()
    {
        // �����Ͱ� ĵ�鿡 ��������� ��ȣ�ۿ� ����
        if (Vector3.Distance(transform.position, candle.transform.position) <= interactDistance)
        {
            if (Input.GetKeyDown(KeyCode.F))  // F Ű�� ���� ����
            {
                // �����ͷ� ���� ���� ���� ���� ��
                candleController.LightCandle();
            }
        }
    }
}
