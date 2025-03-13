using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    // Ray
    private Ray ray;
    private RaycastHit hit;
    private float maxDistance = 3f;
    public LayerMask layerMask;

    // Pivot
    [SerializeField] Transform camPivot;

    // Item
    private ItemHandler itemHandler;
    public Action inputDitect;
    private bool isInput;

    private void Start()
    {
        inputDitect += InputDitected;
        isInput = false;
        if (camPivot == null)
            camPivot = transform.Find("CamPivot");
    }

    private void Update()
    {
        ray = new Ray(camPivot.position, camPivot.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            if (hit.collider != null)
                Hit(hit);
        }
    }

    private void Hit(RaycastHit hit)
    {
        switch (hit.collider.tag)
        {
            case "Item":
                GetItem(hit);
                break;
            case "Puzzle":
                ItemInteraction(hit);
                break;
            default:
                Debug.LogWarning("Hit : 예외 발생");
                break;
        }
    }
    private void GetItem(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<ItemHandler>(out itemHandler))
        {

        }
        isInput = false;
    }

    private void ItemInteraction(RaycastHit hit)
    {
        Debug.Log("ItemInteraction");
        isInput = false;
    }

    public void InputDitected()
    {
        isInput = true;
    }
}
