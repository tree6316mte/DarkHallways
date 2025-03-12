using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    public ParticleSystem flameParticles; //불나는 파티클 시스템
    public Material flameMaterial; // 불나는 매터리얼
    public Light candleLight; // 캔들의 빛

    private bool isFlameOn = false; // 불과 빛이 켜졌는지 여부
    private bool hasBeenLit = false; // 라이터로 불을 붙였는지 여부


    void Start()
    {
        SetFlameState(isFlameOn); //시작할때 불과 빛이 꺼져있게 설정
    }

    // 라이터로 불을 붙이는 함수
    public void LightCandle()
    {
        if (!hasBeenLit) // 불이 이미 붙은 상태라면 다시 켜지지 않도록
        {
            hasBeenLit = true; // 불을 붙였음을 기록
            ToggleFlame(true); // 불과 빛 켜기
        }
    }
    //불과 빛을 켜고 끄는 함수
    public void ToggleFlame(bool state)
    {
        ifFlameOn = state;
        SetFlameState(isFlameOn);
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

    void Update()
    {
        
    }
}
