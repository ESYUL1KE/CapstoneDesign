using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTest : MonoBehaviour
{
    public GameObject cardPrefab; // ī�� ������
    public Transform cardSpawnPoint; // ī�尡 ������ ��ġ
    public float cardOverlapOffset = 0.1f; // ī�� ���� ��ħ ����

    private int cardCount = 0; // ������ ī�� ��

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void SpawnCard()
    {
        // ī�� ����
        GameObject newCard = Instantiate(cardPrefab, cardSpawnPoint.position, Quaternion.identity);

        // ī�� ��ġ ����
        Vector3 offset = new Vector3(cardOverlapOffset * cardCount, 0f, 0f);
        newCard.transform.position += offset;

        // ������ ī�� �� ����
        cardCount++;
    }
}
