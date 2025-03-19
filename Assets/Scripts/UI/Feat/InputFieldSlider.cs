using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldSlider : MonoBehaviour
{
    public Slider slider;
    public TMP_InputField inputField;

    public int minValue = 0;  // 최소값
    public int maxValue = 100; // 최대값

    private bool isUpdating = false; // 무한 루프 방지 플래그

    private Action<int> onChanged;

    void Start()
    {
        // Slider 최소/최대값 설정
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.wholeNumbers = true; // ★ 정수만 사용하도록 설정

        // 초기 동기화
        // slider.value = Mathf.Clamp(Mathf.RoundToInt(slider.value), minValue, maxValue);
        // inputField.text = slider.value.ToString();

        // 이벤트 리스너 등록
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        inputField.onEndEdit.AddListener(OnInputFieldValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        if (isUpdating) return; // 무한 루프 방지
        isUpdating = true;
        int intValue = Mathf.RoundToInt(value); // float을 int로 변환
        inputField.text = intValue.ToString();
        isUpdating = false;
        onChanged?.Invoke(intValue);
    }

    void OnInputFieldValueChanged(string text)
    {
        if (isUpdating) return; // 무한 루프 방지
        if (int.TryParse(text, out int value))
        {
            // 입력된 값이 범위를 벗어나면 보정
            value = Mathf.Clamp(value, minValue, maxValue);

            isUpdating = true;
            slider.value = value;
            inputField.text = value.ToString(); // 다시 보정된 값 표시
            isUpdating = false;
            onChanged?.Invoke(value);
        }
        else
        {
            // 잘못된 입력이면 현재 Slider 값 유지
            inputField.text = Mathf.RoundToInt(slider.value).ToString();
        }
    }


    public void Setup(Action<int> valueChangeAction = null)
    {
        onChanged = valueChangeAction;
    }

    public void SetValue(int newValue)
    {
        StartCoroutine(UpdateInputField(newValue));
        // Debug.Log("WTF : " + newValue);
        // gameObject.SetActive(true); // UI 활성화 후 텍스트 변경
        // newValue = Mathf.Clamp(newValue, minValue, maxValue);
        // // slider.value = newValue;
        // inputField.text = newValue.ToString();
    }
    IEnumerator UpdateInputField(int newValue)
    {
        yield return null; // 한 프레임 기다리기
        gameObject.SetActive(true); // UI 활성화 후 텍스트 변경
        newValue = Mathf.Clamp(newValue, minValue, maxValue);
        slider.value = newValue;
        inputField.text = newValue.ToString();
    }

    public int GetValue()
    {
        return Mathf.RoundToInt(slider.value);
    }
}