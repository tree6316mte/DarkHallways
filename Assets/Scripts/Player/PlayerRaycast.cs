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
    public static Action inputDetect;
    private bool isEInput;
    Player player;

    // InteractiveItem
    private InteractiveItem interactiveItemHandler;
    private bool isClicked;
    public static Action clickAction;


    private void Start()
    {
        player = GetComponent<Player>();

        inputDetect += InputDetected;
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
            {
                if (isEInput && hit.collider.gameObject.TryGetComponent<ItemHandler>(out itemHandler))
                    player.GetItem(itemHandler);
                
                else if (isClicked && hit.collider.gameObject.TryGetComponent<InteractiveItem>(out interactiveItemHandler))
                    itemHandler.UseItem(interactiveItemHandler);
                
                else if (hit.collider.gameObject.TryGetComponent<InteractiveItem>(out interactiveItemHandler))
                    itemInfoText.text = itemHandler.GetInfoText(hit);
                
                else
                    itemInfoText.text = "올바른 대상이 아닙니다.";
            }
        }

        else
            itemInfoText.text = string.Empty;

        isEInput = isClicked = false;
    }

    public void InputDetected()
    {
        isEInput = true;
    }

    public void ClickDetected()
    {
        isClicked = true;
    }
}
