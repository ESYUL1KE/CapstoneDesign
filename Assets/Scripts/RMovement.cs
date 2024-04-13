using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMovement : MonoBehaviour
{

    public GameObject[] objects;

    // �ʱ� ũ�⸦ ������ �迭
    private Vector3[] originalScales;

    void Start()
    { 
        // �迭 ũ�� �ʱ�ȭ
        originalScales = new Vector3[objects.Length];

        // �� ������Ʈ�� �ʱ� ũ�� ����
        for (int i = 0; i < objects.Length; i++)
        {
            originalScales[i] = objects[i].transform.localScale;
        }
    }

    void Update()
    {
        // ���콺 �̺�Ʈ�� Update()���� ó��
        for (int i = 0; i < objects.Length; i++)
        {
            if (IsMouseOverObject(objects[i]))
            {
                // ���콺�� ������Ʈ ���� ���� �� ũ�⸦ 2��� ����
                objects[i].transform.localScale = originalScales[i] * 2f;
            }
            else
            {
                // ���콺�� ������Ʈ ���� ���� �� ���� ũ��� ���ƿ�
                objects[i].transform.localScale = originalScales[i];
            }
        }

        
    }


    // ������Ʈ ���� ���콺�� �ִ��� Ȯ���ϴ� �Լ�
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

}
