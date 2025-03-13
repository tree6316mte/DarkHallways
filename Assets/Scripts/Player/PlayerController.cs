using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class PlayerController : MonoBehaviour
{

    [Header("Move")]
    public float speed;
    private Vector2 curMoveInput;
    private Rigidbody _rigidbody;

    [Header("Look")]
    private Vector2 curLookInput;
    [SerializeField] private Transform camContainer;
    [SerializeField] private float lookSpeed;
    [SerializeField] private float maxXLook;
    [SerializeField] private float minXLook;
    [SerializeField] private bool CursurLockState;
    private float curCamX;


    private void Awake()
    {
        // Move
        _rigidbody = GetComponent<Rigidbody>();
        speed = (speed == 0) ? 5f : speed;

        // Look
        lookSpeed = 0.3f;
        if (camContainer == null)
            camContainer = GameObject.FindWithTag("CameraPivot").GetComponent<Transform>();
        maxXLook = (maxXLook == 0) ? 50f : maxXLook;
        minXLook = (minXLook == 0) ? -30f : minXLook;
        Cursor.lockState = (CursurLockState) ? CursorLockMode.Locked : CursorLockMode.None;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        Look();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase== InputActionPhase.Performed)
            curMoveInput = context.ReadValue<Vector2>();
        else if (context.phase== InputActionPhase.Canceled)
            curMoveInput = Vector2.zero;
    }

    private void Move()
    {
        Vector3 vec = transform.forward * curMoveInput.y + transform.right * curMoveInput.x;
        vec *= speed;
        vec.y = _rigidbody.velocity.y;

        _rigidbody.velocity = vec;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        curLookInput = context.ReadValue<Vector2>();

    }

    private void Look()
    {
        curCamX += curLookInput.y * lookSpeed;
        curCamX = Mathf.Clamp(curCamX, minXLook, maxXLook);

        camContainer.localEulerAngles = new Vector3(-curCamX, 0, 0);
        transform.eulerAngles += new Vector3(0, curLookInput.x * lookSpeed, 0);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {

    }
}
