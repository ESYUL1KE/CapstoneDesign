using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CardMove : MonoBehaviour
{
    private Vector3 offset;
    private float distanceToCamera;

        //크기 저장
    private Vector3 originalScale;
    private Vector3 originalPosition;

    public bool dragdown = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        dragdown = false;

        if (IsMouseOverObject(this.gameObject))
        {
            // 마우스가 오브젝트 위에 있을 때 크기를 2배로 변경
            this.gameObject.transform.localScale = originalScale * 2f;
        }
        else
        {
            // 마우스가 오브젝트 위에 없을 때 원래 크기로 돌아옴
            this.gameObject.transform.localScale = originalScale;
        }


    }

    void OnMouseUp()
    {
        dragdown = false;
        transform.position = Vector3.Lerp(transform.position, originalPosition, 5f * Time.deltaTime);
        //카드의 원래 위치값 저장
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Panel")
        {
            Destroy(this.gameObject);
        }
    }
    

    bool IsMouseOverObject(GameObject obj)
    {
        // 마우스 포인터 위치를 기준으로 Ray를 쏘아 충돌 체크
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject == obj)
            {
                return true;
            }
        }
        return false;
    }



    void OnMouseDown()
    {
        dragdown = true;
        originalPosition = transform.position;
        distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        offset = transform.position - GetMouseWorldPosition();
    }

  

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
        
        
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = distanceToCamera;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


}
