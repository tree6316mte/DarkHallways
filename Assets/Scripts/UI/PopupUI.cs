using UnityEngine;
using UnityEngine.UI;
using System;

public class PopupUI : BaseUI
{
    [SerializeField] private Text messageText;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;

    private Action onConfirm;
    private Action onCancel;

    /// <summary>
    /// 팝업 초기화
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();

        if (confirmButton != null)
            confirmButton.onClick.AddListener(() => Confirm());

        if (cancelButton != null)
            cancelButton.onClick.AddListener(() => Cancel());
    }

    /// <summary>
    /// 팝업 설정
    /// </summary>
    public void Setup(string message, Action onConfirmAction, Action onCancelAction = null)
    {
        if (messageText != null)
            messageText.text = message;

        onConfirm = onConfirmAction;
        onCancel = onCancelAction;
    }

    /// <summary>
    /// 확인 버튼 동작
    /// </summary>
    private void Confirm()
    {
        onConfirm?.Invoke();
        OnHide();
    }

    /// <summary>
    /// 취소 버튼 동작
    /// </summary>
    private void Cancel()
    {
        onCancel?.Invoke();
        OnHide();
    }
}
