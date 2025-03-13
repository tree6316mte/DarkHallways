using System;
using TMPro;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    // Ray
    private Ray ray;
    private RaycastHit hit;
    private float maxDistance = 5f;
    public LayerMask layerMask;

    // Pivot
    [SerializeField] Transform camPivot;

    // Item
    public static Action inputDetect;
    [SerializeField] private TextMeshProUGUI itemInfoText;
    private ItemHandler itemHandler;
    private bool isInput;
    PlayerState playerState;

    private void Start()
    {
        playerState = GetComponent<PlayerState>();

        inputDetect += InputDetected;
        isInput = false;
        if (camPivot == null)
            camPivot = transform.Find("CamPivot");
    }

    private void Update()
    {
        ray = new Ray(camPivot.position, camPivot.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask) && isInput)
        {
            if (hit.collider != null)
                GetItem(hit);
        }

        else if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            if (hit.collider != null)
                itemInfoText.text = GetInfoText(hit);
        }

        else
            itemInfoText.text = string.Empty;

        isInput = false;
    }

    private void GetItem(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<ItemHandler>(out itemHandler))
        {
            Debug.Log(itemHandler.GetItemInfo());
            playerState.hasItem = itemHandler.itemInstance;
            Destroy(hit.collider.gameObject);
        }
    }

    private string GetInfoText(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<ItemHandler>(out itemHandler))
        {
            return itemHandler.GetItemInfo();
        }
        return string.Empty;
    }

    public void InputDetected()
    {
        isInput = true;
    }
}
