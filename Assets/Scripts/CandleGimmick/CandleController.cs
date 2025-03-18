using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : PuzzleHandler
{
    public CandleData candleData;
    public ParticleSystem flameParticles;
    public Material flameMaterial;
    public Light candleLight;
    private static int litCandleCount = 0; // 켜진 양초 개수
    private static readonly int requiredCandleCount = 3; // 2번, 3번, 4번 총 3개가 켜져야 함(1번이 거짓말쟁이)
    private static HashSet<int> litCandles = new HashSet<int>(); // 현재 켜진 양초 ID 저장

    public int candleID;

    void Start()
    {
        if (candleData != null)
        {
            candleData.isLit = false;
            candleData.hasBeenLit = false;
        }

        SetFlameState(false);
    }

    // 라이터로 불을 껐다켰다 토글.
    public void LightCandle()
    {
        {
            if (candleData.isLit)
            {
                // 이미 켜져 있다면 불을 끄는 동작
                candleData.isLit = false;
                candleData.hasBeenLit = false;
                ToggleFlame(false);

                // 켜진 양초 개수 감소
                if (litCandles.Contains(candleID))
                {
                    litCandles.Remove(candleID);
                    litCandleCount--;
                }

                Debug.Log("불이 꺼졌습니다.");
            }
            else
            {
                // 꺼져 있다면 불을 켜는 동작
                if (!candleData.hasBeenLit)
                {
                    candleData.hasBeenLit = true;
                }
                candleData.isLit = true;
                ToggleFlame(true);

                if (!litCandles.Contains(candleID))
                {
                    litCandles.Add(candleID);
                    litCandleCount++;
                }
            }

                // 2번, 3번, 4번 캔들이 모두 켜지고 1번이 꺼져야만 문이 열려야 함
                if (litCandleCount == requiredCandleCount && !litCandles.Contains(1))
                {
                    Debug.Log("문이 열렸다!");
                    // 문이 열리는 동작 추가 가능
                }
                else if (litCandles.Contains(1))
                {
                    // 1번이 켜져 있을 때 문이 열리지 않도록 설정
                    Debug.Log("1번 캔들이 켜져있어 문이 열리지 않음");
                }
            
        }
    }

    public void ToggleFlame(bool state)
    {
        SetFlameState(state);
    }

    private void SetFlameState(bool state)
    {
        if (flameParticles == null || flameMaterial == null || candleLight == null)
        {
            Debug.LogError("에디터에서 인스펙터 설정되지않음");
            return;
        }
        if (state)
        {
            flameParticles.Play();
            flameMaterial.EnableKeyword("_EMISSION");
            candleLight.enabled = true;
        }
        else
        {
            flameParticles.Stop();
            flameMaterial.DisableKeyword("_EMISSION");
            candleLight.enabled = false;
        }
    }
}
