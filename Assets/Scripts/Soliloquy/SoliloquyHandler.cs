using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoliloquyHandler : MonoBehaviour
{
    [Header("Ray")]
    private Ray ray;
    private RaycastHit hit;
    private float maxDistance = 5f;
    public LayerMask layerMask;

    [Header("CamPivot")]
    [SerializeField] Transform playerCamPivot;

    private Coroutine coroutine;
    [SerializeField] TextMeshProUGUI description;

    public void OnSoliloquy()
    {
        ray = new Ray(playerCamPivot.position, playerCamPivot.forward);

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            Debug.Log("아이고난");
            if (hit.collider.TryGetComponent(out SoliloquyObject _object))
            {
                Debug.Log("아이고난2");
                if (coroutine != null) StopCoroutine(coroutine);
                coroutine = StartCoroutine(ShowSoliloquy(_object.soliloquy.description));
            }
        }
    }

    public IEnumerator ShowSoliloquy(string description)
    {
        this.description.gameObject.SetActive(true);
        this.description.text = description;
        yield return CoroutineAlpha(0f, 1f);
        yield return new WaitForSeconds(1f);
        yield return CoroutineAlpha(1f, 0f);
        this.description.gameObject.SetActive(false);
    }

    private IEnumerator CoroutineAlpha(float startAlpha, float endAlpha)
    {
        float fadeDuration = 1f; // 페이드 시간
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration + 0.1f)
        {
            description.alpha = Mathf.Lerp(startAlpha, endAlpha, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        description.alpha = endAlpha;
    }
}
