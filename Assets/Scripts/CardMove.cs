using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CardMove : MonoBehaviour
{
    private Vector3 offset;
    private float distanceToCamera;

        //ũ�� ����
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
            // ���콺�� ������Ʈ ���� ���� �� ũ�⸦ 2��� ����
            this.gameObject.transform.localScale = originalScale * 2f;
        }
        else
        {
            // ���콺�� ������Ʈ ���� ���� �� ���� ũ��� ���ƿ�
            this.gameObject.transform.localScale = originalScale;
        }


    }

    void OnMouseUp()
    {
        dragdown = false;
        transform.position = Vector3.Lerp(transform.position, originalPosition, 5f * Time.deltaTime);
        //ī���� ���� ��ġ�� ����
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
        // ���콺 ������ ��ġ�� �������� Ray�� ��� �浹 üũ
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
