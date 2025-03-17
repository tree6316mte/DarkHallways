using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 죽었는지 처리와 아이템 상황관리하는 클래스
public class Player : MonoBehaviour
{
    //private bool isDead;
    private bool isGetFlash;
    private bool isFlashing;
    public Item hasItem;
    public static Action throwAction;
    public static Action flashAction;
    Rigidbody itemRigidbody;
    [SerializeField] GameObject SpotLight;

    private void Start()
    {
        //isDead = false;
        isGetFlash = false;
        isFlashing = false;
        throwAction += ThrowItem;
        flashAction += UseFlash;
    }

    private void DisplayHasItem()
    {
        string str = (hasItem != null) ? "가진 아이템 : " + hasItem.itemName : "비어있음";
        Debug.Log($"{str}");
    }

    public void GetFlash()
    {
        // 플래시 습득시 호출
        isGetFlash = true;
        hasItem = null;
    }

    public void UseFlash()
    {
        if (isGetFlash && SpotLight != null)
        {
            isFlashing = !isFlashing;
            SpotLight.SetActive(isFlashing);
        }
    }

    public void GetItem(ItemHandler newItem)
    {
        Debug.Log("호출 GetItem");

        hasItem = newItem.itemInstance;
        newItem.gameObject.SetActive(false);
        newItem.transform.SetParent(transform);
        newItem.gameObject.name = "myItem"; // 참조하기 쉽게 오브젝트 이름 바꿈
        newItem.OnGetItem();
    }

    public void ThrowItem()
    {
        if (hasItem != null)
        {
            float yRotation = transform.eulerAngles.y;
            Vector3 spawnPosition = transform.position + transform.forward;
            spawnPosition.y = 1f;
            GameObject myItem = transform.Find("myItem").gameObject;
            Rigidbody _rigidbody;

            myItem.transform.SetParent(null);
            myItem.transform.position = spawnPosition;
            myItem.transform.rotation = Quaternion.identity;
            myItem.gameObject.SetActive(true);

            if (myItem.TryGetComponent<Rigidbody>(out _rigidbody))
                _rigidbody.AddForce((yRotation * transform.forward).normalized * 2f, ForceMode.Impulse);
            else
            {
                _rigidbody = myItem.AddComponent<Rigidbody>();
                _rigidbody.AddForce((yRotation * transform.forward).normalized * 2f, ForceMode.Impulse);
            }

            hasItem = null;
        }
        else
            Debug.Log("버릴 아이템이 없습니다!");
    }
}
