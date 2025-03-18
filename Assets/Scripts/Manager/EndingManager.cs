using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{

    [SerializeField] private string mainSceneName;
    [SerializeField] private RectTransform creditPanel;
    public TextMeshProUGUI skipText;

    [SerializeField] private float scrollSpeed = 100f; // 스크롤 속도
    [SerializeField] private float endPosY = 3000;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartEndingScroll());
        skipText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && skipText.gameObject.activeSelf)
        {
            SceneManager.LoadScene(mainSceneName);
        }
    }

    IEnumerator StartEndingScroll()
    {
        yield return new WaitForSecondsRealtime(2f);
        skipText.gameObject.SetActive(true);
        StartCoroutine(ShowSkipText());

        while (creditPanel.anchoredPosition.y < endPosY)
        {
            creditPanel.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
            yield return null;
        }

        creditPanel.anchoredPosition = new Vector2(creditPanel.anchoredPosition.x, endPosY);

        yield return new WaitForSecondsRealtime(2f);

        SceneManager.LoadScene(mainSceneName);
    }

    IEnumerator ShowSkipText()
    {
        skipText.alpha = 0f;
        while (skipText.alpha < 1f)
        {
            skipText.alpha += 0.5f * Time.deltaTime;
            yield return null;
        }
        skipText.alpha = 1f;
    }
}
