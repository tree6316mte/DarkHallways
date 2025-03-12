using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    public ParticleSystem flameParticles; //�ҳ��� ��ƼŬ �ý���
    public Material flameMaterial; // �ҳ��� ���͸���
    public Light candleLight; // ĵ���� ��

    private bool isFlameOn = false; // �Ұ� ���� �������� ����
    private bool hasBeenLit = false; // �����ͷ� ���� �ٿ����� ����


    void Start()
    {
        SetFlameState(isFlameOn); //�����Ҷ� �Ұ� ���� �����ְ� ����
    }

    // �����ͷ� ���� ���̴� �Լ�
    public void LightCandle()
    {
        if (!hasBeenLit) // ���� �̹� ���� ���¶�� �ٽ� ������ �ʵ���
        {
            hasBeenLit = true; // ���� �ٿ����� ���
            ToggleFlame(true); // �Ұ� �� �ѱ�
        }
    }
    //�Ұ� ���� �Ѱ� ���� �Լ�
    public void ToggleFlame(bool state)
    {
        ifFlameOn = state;
        SetFlameState(isFlameOn);
    }

    private void SetFlameState(bool state)
    {
        if(state)
        {
            flameParticles.Play(); // ���� ���� �� ��ƼŬ �ý��� ���
            flameMaterial.EnableKeyword("_EMISSION"); // ���� ���� �� ���͸����� emission Ȱ��ȭ
            candleLight.enabled = true; // ���� ���� �� �� Ȱ��ȭ
        }
        else
        {
            flameParticles.Stop(); // ���� ���� �� ��ƼŬ �ý��� ����
            flameMaterial.DisableKeyword("_EMISSION"); // ���� ���� �� ���͸����� emission ��Ȱ��ȭ
            candleLight.enabled = false; // ���� ���� �� �� ��Ȱ��ȭ
        }
    }

    void Update()
    {
        
    }
}
