using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Light lightSource;   // 전등의 Light 컴포넌트
    private float originIntensity;  // 전등의 현재 밝기
    public float minIntensity = 3f;  // 최소 밝기
    public float flickerSpeed = 2f;  // 깜빡이는 속도

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();  // Light 컴포넌트 찾기
        }

        originIntensity = lightSource.intensity;
    }

    void FixedUpdate()
    {
        lightSource.intensity = Mathf.PingPong(Time.time * flickerSpeed, originIntensity - minIntensity) + minIntensity;
    }
}
