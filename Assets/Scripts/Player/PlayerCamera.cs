using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    GameObject camera;
    [SerializeField] private Transform player;

    private void Awake()
    {
        camera = this.gameObject;
    }

    private void LateUpdate()
    {
        updateCamera();
    }

    private void updateCamera()
    {
        camera.transform.position = player.position;
        camera.transform.rotation = player.rotation;
    }
}
