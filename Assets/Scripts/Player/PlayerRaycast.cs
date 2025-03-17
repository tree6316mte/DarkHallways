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
    private ItemHandler itemHandler;
    [SerializeField] private TextMeshProUGUI itemInfoText;
    public static Action interactAction;
    private bool isEInput;
    Player playerItem;

    // InteractiveItem
    private InteractiveItemHandler interactiveItemHandler;
    private bool isClicked;
    public static Action clickAction;


    private void Start()
    {
        playerItem = GetComponent<Player>();

        interactAction += InputDetected;
        clickAction += ClickDetected;

        isEInput = false;
        isClicked = false;
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
                ProcessHitCollider(hit);
        }
        else
            itemInfoText.text = string.Empty;

        isEInput = isClicked = false;
    }

    private void ProcessHitCollider(RaycastHit hit)
    {
        // ItemHandler, UI에 Item 정보를 띄우거나 해당 아이템 습득
        if (isEInput && playerItem.hasItem == null && hit.collider.gameObject.TryGetComponent<ItemHandler>(out itemHandler))
            playerItem.GetItem(itemHandler);

        else if (hit.collider.gameObject.TryGetComponent<ItemHandler>(out itemHandler))
            itemInfoText.text = itemHandler.GetInfoText(hit);

        // interactiveItemHandler
        if (isClicked && (playerItem.hasItem != null) && hit.collider.gameObject.TryGetComponent<InteractiveItemHandler>(out interactiveItemHandler))
                interactiveItemHandler.UseItem(playerItem);

        else if (playerItem.hasItem != null && hit.collider.gameObject.TryGetComponent<InteractiveItemHandler>(out interactiveItemHandler))
            itemInfoText.text = interactiveItemHandler.ItemValidator(playerItem);
    }

    public void InputDetected()
    {
        isEInput = true;
        Debug.Log("inputDetected");
    }

    public void ClickDetected()
    {
        isClicked = true;
        Debug.Log("ClickDetected");
    }
}
