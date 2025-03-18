using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 퓨즈 색상 관리
public enum FuseColor { Red, Blue, Green }

public class Fusee : MonoBehaviour
{
    public FuseColor fuseColor;  // 퓨즈 색상
    public string fuseName;      // 퓨즈 이름
    public int fuseCode;         // 퓨즈 코드 

    public FuseSlot currentSlot;  // 현재 퓨즈가 삽입된 슬롯
    private GameObject myItem;     // myItem 오브젝트
    private bool isHoldingFuse = false; // 퓨즈를 들고 있는지 여부

    private void Start()
    {
        // "myItem"을 자식 오브젝트에서 찾기
        // myItem = transform.Find("myItem")?.gameObject;

        // // myItem이 없으면 에러 출력
        // if (myItem == null)
        // {
        //     Debug.LogError("myItem 오브젝트를 찾을 수 없습니다.");
        // }
        // else
        // {
        //     // myItem이 초기화될 때 활성화되도록 설정
        //     myItem.SetActive(true);
        // }
    }

    private void OnDisable()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        // E 키로 퓨즈를 들거나 내려놓기
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingFuse)
            {
                DropFuse();  // 퓨즈를 내려놓기
            }
            else
            {
                PickupFuse();  // 퓨즈를 들기
            }
        }

        // 좌클릭으로 퓨즈를 내려놓기 (마우스 위치로)
        if (Input.GetMouseButtonDown(0) && isHoldingFuse)
        {
            PlaceFuseAtMousePosition();  // 마우스 클릭 위치에 퓨즈 놓기
        }
    }

    // 퓨즈를 슬롯에 삽입하는 함수
    public void InsertIntoSlot(FuseSlot slot)
    {
        currentSlot = slot;
        slot.InsertFuse(this);  // 현재 퓨즈를 해당 슬롯에 삽입
        gameObject.transform.SetParent(slot.transform);  // 퓨즈를 슬롯의 자식으로 설정하여 고정
        gameObject.transform.localPosition = Vector3.zero;  // 슬롯 내에서 퓨즈의 위치를 고정
        gameObject.transform.localRotation = Quaternion.identity;  // 슬롯 내에서 퓨즈의 회전도 고정

        // 퓨즈가 슬롯에 삽입되면 손에서 떨어진 상태로 처리
        isHoldingFuse = false;

        Debug.Log($"{fuseName} 퓨즈가 슬롯에 삽입됨.");
    }

    // 퓨즈를 슬롯에서 제거하는 함수
    public void RemoveFromSlot()
    {
        if (currentSlot != null)
        {
            currentSlot.RemoveFuse();
            currentSlot = null;
            gameObject.transform.SetParent(null);  // 슬롯에서 제거 시 부모를 null로 설정
            gameObject.SetActive(true);  // 손에 들 수 있도록 활성화
            Debug.Log($"{fuseName} 퓨즈가 슬롯에서 제거됨.");
        }
    }

    // 퓨즈를 들 때 처리
    private void PickupFuse()
    {
        if (myItem != null)
        {
            myItem.SetActive(true);  // myItem을 항상 활성화시켜 하이어라키에서 보이도록
            isHoldingFuse = true;  // 퓨즈를 들고 있다는 상태로 설정
            myItem.transform.SetParent(transform);  // 퓨즈를 손에 들도록 부모 설정
            Debug.Log($"{fuseName} 퓨즈를 들었습니다.");
        }
    }

    // 퓨즈를 내려놓을 때 처리
    private void DropFuse()
    {
        if (myItem != null)
        {
            // myItem을 비활성화하지 않음. 항상 활성화 상태로 유지.
            isHoldingFuse = false;  // 퓨즈를 내려놓은 상태로 설정
            Debug.Log($"{fuseName} 퓨즈를 내려놓았습니다.");
        }
    }

    // 좌클릭으로 퓨즈를 마우스 클릭 위치에 내려놓기
    private void PlaceFuseAtMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // 마우스 위치에서 광선 발사
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("퓨즈를 내려놓을 위치를 클릭했습니다.");
            Vector3 hitPosition = hit.point;  // 마우스 클릭 지점
            myItem.transform.position = hitPosition;  // 클릭한 위치에 퓨즈 배치
            myItem.transform.SetParent(null);  // 부모를 제거해줘서 장면에 독립적으로 두기
            Debug.Log($"{fuseName} 퓨즈를 {hitPosition}에 내려놓았습니다.");
        }
    }

    // 현재 퓨즈가 올바른 슬롯에 있는지 확인
    public bool IsCorrectFuse()
    {
        return currentSlot != null && currentSlot.IsCorrectFuse();
    }

    // 퓨즈가 슬롯에 들어가면 호출
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FuseSlot"))
        {
            FuseSlot slot = other.GetComponent<FuseSlot>();
            if (slot != null && !slot.HasFuse)
            {
                InsertIntoSlot(slot);  // 슬롯이 비어 있으면 퓨즈 삽입
                GameManager.Instance.player.hasItem = null;
            }
        }
    }
}
