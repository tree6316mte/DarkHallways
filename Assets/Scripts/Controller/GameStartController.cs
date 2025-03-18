using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartController : MonoBehaviour
{
    public GameObject player;
    public GameObject playerAim;
    public GameObject playerItemInfo;
    public CanvasGroup fadeout;
    public List<Transform> cameraTransformList;

    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.Instance.chapterProgress)
        {
            case 0:
                StartCoroutine(CoroutineCameraMove());
                break;
            case 1:
                PlayerSetEnable();
                break;
            case 2:
                PlayerSetEnable();
                break;
            case 3:
                PlayerSetEnable();
                break;
            default:
                StartCoroutine(CoroutineCameraMove());
                break;
        }
    }
    private IEnumerator CoroutineCameraMove()
    {
        fadeout.gameObject.SetActive(true);

        Camera.main.gameObject.transform.position = cameraTransformList[0].position;
        Camera.main.gameObject.transform.rotation = cameraTransformList[0].rotation;

        yield return StartCoroutine(CoroutineCanvasGroupAlpha(fadeout, 1f, 0f));

        yield return new WaitForSeconds(1f);

        for (int i = 0; i + 1 < cameraTransformList.Count; i++)
        {
            yield return StartCoroutine(CoroutineObjectMove(Camera.main.gameObject, cameraTransformList[i], cameraTransformList[i + 1]));
            yield return new WaitForSeconds(1f);
        }

        yield return StartCoroutine(CoroutineCanvasGroupAlpha(fadeout, 0f, 1f));

        // fadeout.gameObject.SetActive(false);
        PlayerSetEnable();


        yield return StartCoroutine(CoroutineCanvasGroupAlpha(fadeout, 1f, 0f));


    }
    private IEnumerator CoroutineObjectMove(GameObject _object, Transform startPos, Transform endPos)
    {
        float moveDuration = 1f; // 이동 시간
        float timeElapsed = 0f;
        while (timeElapsed < moveDuration + 0.1f)
        {
            _object.transform.position = Vector3.Lerp(startPos.position, endPos.position, timeElapsed / moveDuration);   // 선형보간
            _object.transform.rotation = Quaternion.Lerp(startPos.rotation, endPos.rotation, timeElapsed / moveDuration);   // 선형보간
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        _object.transform.position = endPos.position;
        _object.transform.rotation = endPos.rotation;
    }
    private IEnumerator CoroutineCanvasGroupAlpha(CanvasGroup canvasGroup, float startAlpha, float endAlpha)
    {
        float fadeDuration = 1f; // 페이드 시간
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration + 0.1f)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = endAlpha;
    }

    private void PlayerSetEnable()
    {
        Camera.main.gameObject.GetComponent<PlayerCamera>().isGameStart = true;
        player.gameObject.SetActive(true);
        playerAim.gameObject.SetActive(true);
        playerItemInfo.gameObject.SetActive(true);
    }
}
