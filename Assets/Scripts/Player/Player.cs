using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 죽었는지 처리와 아이템 상황관리하는 클래스
public class Player : MonoBehaviour
{
    private bool isDead;
    public Item hasItem;
    public static Action throwAction;
    [SerializeField] private GameObject memorizeObject;
    Rigidbody itemRigidbody;

    private void Start()
    {
        throwAction += ThrowItem;
    }

    private void DisplayHasItem()
    {
        string str = (hasItem != null) ? "가진 아이템 : " + hasItem.itemName : "비어있음";
        Debug.Log($"{str}");
    }

    public void GetItem(ItemHandler newItem)
    {
        Debug.Log("호출 GetItem");

        hasItem = newItem.itemInstance;
        memorizeObject = newItem.gameObject;
        newItem.gameObject.SetActive(false);
        newItem.transform.SetParent(transform);
    }

    public void ThrowItem()
    {
        if (hasItem != null)
        {
            Vector3 spawnPosition = transform.position + transform.forward;
            spawnPosition.y += .7f;
            GameObject item = Instantiate(memorizeObject, spawnPosition, transform.rotation);
            if (item.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddForce(transform.forward * 2f, ForceMode.Impulse);
            }
            else
            {
               Rigidbody _rigidbody = memorizeObject.AddComponent<Rigidbody>();
                _rigidbody.AddForce(transform.forward * 2f, ForceMode.Impulse);
            }

            hasItem = null;
            memorizeObject = null;
        }
        else
            Debug.Log("버릴 아이템이 없습니다!");
    }
}
