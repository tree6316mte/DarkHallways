using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

// 사용자 정의 속성
[System.AttributeUsage(System.AttributeTargets.Method)]
public class  ItemEventAttribute : System.Attribute
{
    public int ItemCode { get; }

    public ItemEventAttribute(int itemCode)
    {
        ItemCode = itemCode;
    }
}

public class EventContainer : MonoBehaviour
{
    [ItemEvent(0)]
    public void DebugItemCode(ItemHandler itemHandler)
    {
        Debug.Log($"아이템 코드 : {itemHandler.itemCode}");
    }

    [ItemEvent(1)]
    public void UnLock(ItemHandler itemHandler)
    {
        Debug.Log("UnLock 호출됨");
    }

    [ItemEvent(11)]
    public void OpenDoor11(ItemHandler itemHandler)
    {
        OpenDoor(itemHandler);
    }
    [ItemEvent(22)]
    public void OpenDoor22(ItemHandler itemHandler)
    {
        OpenDoor(itemHandler);
    }
    public void OpenDoor(ItemHandler itemHandler)
    {
        PuzzleHandler puzzle = itemHandler.puzzleHandler;
        puzzle.isOpen = true;
        puzzle.InteractPuzzle();
    }
    /// <summary>
    /// 호출 시점은 Interactive Item이 레이캐스트로 부터 호출 됐을 때
    /// 호출 흐름 -> PlayerRaycast -> Interactive Item -> UseItem (ItemHandler) -> EventContainer
    /// </summary>

    private Dictionary<int, Action<ItemHandler>> eventDictionary;

    private void Awake()
    {
        InitializeEventDictionary();
        Debug.Log($"등록된 이벤트 갯수 : {eventDictionary.Count}");
    }

    #region 메소드 등록 자동화
    private void InitializeEventDictionary()
    {
        // eventDictionary 초기화
        // 클래스 메소드 식별해서 배열 생성
        // 메소드 순회하며 구독
        eventDictionary = new Dictionary<int, Action<ItemHandler>>();

        MethodInfo[] methods = typeof(EventContainer).GetMethods(BindingFlags.Public | BindingFlags.Instance);
        foreach (MethodInfo method in methods)
        {
            // 메소드가 커스텀 속성을 사용하고 있는지 검사
            ItemEventAttribute itemAttribute = (ItemEventAttribute)Attribute.GetCustomAttribute(method, typeof(ItemEventAttribute));
            if (itemAttribute != null && ValidateMethod(method))
            {
                // ItemHandler 대리자를 만듦, 인스턴스는 이 클래스를 던지고, 메소드 정보는 메소드를 순회하며 던짐
                Action<ItemHandler> action = (Action<ItemHandler>)Delegate.CreateDelegate(typeof(Action<ItemHandler>), this, method);

                eventDictionary[itemAttribute.ItemCode] = action;
            }
        }
    }

    private bool ValidateMethod(MethodInfo method)
    {
        ParameterInfo[] parameters = method.GetParameters();
        return (parameters.Length == 1 && parameters[0].ParameterType == typeof(ItemHandler));
    }

    public void GetFuctionFromItemCode(ItemHandler itemHandler)
    {
        if (eventDictionary.TryGetValue(itemHandler.itemCode, out Action<ItemHandler> action))
            itemHandler.useItemEvent += action;
        else
            Debug.LogWarning($"연결된 함수 찾을 수 없음 : {itemHandler.gameObject.name}");
    }
    #endregion
}
