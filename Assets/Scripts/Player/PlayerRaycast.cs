using Cinemachine;
using System;
using TMPro;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [Header("Ray")]
    private Ray ray;
    private RaycastHit hit;
    private float maxDistance = 5f;
    public LayerMask layerMask;

    [Header("CamPivot")]
    [SerializeField] Transform playerCamPivot;

    [Header("Item")]
    private ItemHandler itemHandler;
    [SerializeField] private TextMeshProUGUI itemInfoText;
    public static Action interactAction;
    private bool isEInput;
    Player playerItem;

    [Header("InteractiveItem")]
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
        if (playerCamPivot == null)
            playerCamPivot = transform.Find("CamPivot");
    }

    private void Update()
    {
        ray = new Ray(playerCamPivot.position, playerCamPivot.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            if (hit.collider != null)
                ProcessHitCollider(hit);
            else
                itemInfoText.text = string.Empty;
        }
        else
            itemInfoText.text = string.Empty;

        isEInput = isClicked = false;
    }

    private void ProcessHitCollider(RaycastHit hit)
    {
        bool isHit = hit.collider.gameObject.TryGetComponent<ItemHandler>(out itemHandler);

        // 주울 수 있는 아이템
        if (isEInput && isHit && playerItem.hasItem == null && !itemHandler.itemInstance.isThereCam)
            playerItem.GetItem(itemHandler);

        // 아이템 정보 UI 표시
        else if (isHit)
            itemInfoText.text = itemHandler.GetInfoText(hit);

        bool isInterhit = (hit.collider.gameObject.TryGetComponent<InteractiveItemHandler>(out interactiveItemHandler) && playerItem.hasItem != null);

        // 상호 작용 가능한 아이템. 클릭 시 사용
        if (isClicked && isInterhit)
        {
            interactiveItemHandler.UseItem(playerItem.hasItem);
            playerItem.hasItem = null;
        }

        // 상호 작용 가능한지 여부를 UI 표시
        else if (isInterhit)
            itemInfoText.text = interactiveItemHandler.ItemValidator(playerItem.hasItem);
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
