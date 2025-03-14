using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    public CandleData candleData;
    public ParticleSystem flameParticles;
    public Material flameMaterial;
    public Light candleLight;

    private static int litCandleCount = 0; // 켜진 양초 개수
    private static int totalCandles = 5; // 전체 양초 개수

    void Start()
    {
        SetFlameState(candleData.hasBeenLit);
    }

    // 라이터로 불을 붙이는 함수
    public void LightCandle()
    {
        if (!candleData.hasBeenLit)
        {
            candleData.hasBeenLit = true; // 불을 붙였음을 기록.
            candleData.isLit = true;
            ToggleFlame(true);
            litCandleCount++;

            // 모든 양초가 켜졌다면 "성공!" 메시지 출력
            if (litCandleCount >= totalCandles)
            {
                Debug.Log("성공!");
            }
        }
    }

    public void ToggleFlame(bool state)
    {
        SetFlameState(state);
    }

    private void SetFlameState(bool state)
    {
        if(state)
        {
            flameParticles.Play(); // 불을 켰을 때 파티클 시스템 재생
            flameMaterial.EnableKeyword("_EMISSION"); // 불을 켰을 때 매터리얼의 emission 활성화
            candleLight.enabled = true; // 불을 켰을 때 빛 활성화
        }
        else
        {
            flameParticles.Stop(); // 불을 껐을 때 파티클 시스템 정지
            flameMaterial.DisableKeyword("_EMISSION"); // 불을 껐을 때 매터리얼의 emission 비활성화
            candleLight.enabled = false; // 불을 껐을 때 빛 비활성화
        }
    }
}
