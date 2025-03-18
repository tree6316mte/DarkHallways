using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : PuzzleHandler
{
    private bool isWatered = false;
    public float growthDuration = 2f;
    public Transform palm;
    private Vector3 origin;
    private Vector3 targetScale;
    public Color newColor;
    public WaterBottle water;
    private void Start()
    {
        origin = palm.localPosition;
        targetScale = new Vector3(palm.localPosition.x, -1f, palm.localPosition.z);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            WaterPlant();

        }
    }

    public void WaterPlant()
    {
        if (!isWatered && water.isFull)
        {
            // 물 주는 사운드
            isWatered = true; 
            StartCoroutine(WateringPlant());
            ChangeMat();
            InteractPuzzle();
        }
    }


    private IEnumerator WateringPlant()
    {
        float elapsed = 0f;
        while(elapsed < growthDuration)
        {
            palm.localPosition = Vector3.Lerp(origin, targetScale, elapsed / growthDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        palm.localPosition = targetScale;
    }

    private void ChangeMat()
    {
        Transform cover = transform.GetChild(0).GetChild(0);
        Renderer coverRenderer = cover.GetComponent<Renderer>();
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        coverRenderer.GetPropertyBlock(block);
        block.SetColor("_BaseColor", newColor);
        coverRenderer.SetPropertyBlock(block);
    }
}
