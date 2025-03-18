using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    GameObject camera;
    [SerializeField] private Transform player;
    public DialLock dial;

    private void Awake()
    {
        camera = this.gameObject;
    }

    private void LateUpdate()
    {
        if (!dial.isDialOpen) updateCamera();
        else DialCamera();
    }

    private void updateCamera()
    {
        camera.transform.position = player.GetChild(1).gameObject.transform.position;
        camera.transform.rotation = player.GetChild(1).gameObject.transform.rotation;
        player.GetChild(0).gameObject.SetActive(true);
    }

    private void DialCamera()
    {
        camera.transform.position = dial.cameraPos.transform.position;
        camera.transform.rotation = dial.cameraPos.transform.rotation;
        player.GetChild(0).gameObject.SetActive(false);
    }
}
