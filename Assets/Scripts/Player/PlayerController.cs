using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("Move")]
    public float speed;
    private Vector2 curMoveInput;

    [Header("Look")]
    private Rigidbody rigid;
    [SerializeField] private Transform camContainer;
    [SerializeField] private float lookSpeed;
    [SerializeField] private float maxXLook;
    [SerializeField] private float minXLook;
    private float curCamX;


    private void Awake()
    {
        // Move
        rigid = GetComponent<Rigidbody>();
        speed = (speed == 0) ? 5f : speed;

        // Look
        lookSpeed = 0.3f;
        if (camContainer == null)
            camContainer = GameObject.FindWithTag("CameraPivot").GetComponent<Transform>();
        maxXLook = (maxXLook == 0) ? 50f : maxXLook;
        minXLook = (minXLook == 0) ? -30f : minXLook;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        curMoveInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 vec = transform.forward * curMoveInput.x + transform.right * curMoveInput.y;
        vec *= speed;
        vec.y = rigid.velocity.y;

        rigid.velocity = vec;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 curLookInput = context.ReadValue<Vector2>();

        curCamX += curLookInput.y * lookSpeed;
        curCamX = Mathf.Clamp(curCamX, minXLook, maxXLook);

        camContainer.localEulerAngles = new Vector3(-curCamX, 0);
        transform.eulerAngles += new Vector3(0, curLookInput.x * lookSpeed);
    }
}
