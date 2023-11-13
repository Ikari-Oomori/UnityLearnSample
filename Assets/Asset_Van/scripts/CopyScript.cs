using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : SampleScript
{
    public GameObject prefab; // ������ ��� ��������
    public float spacing; // ���������� ����� ��������� �� ��� Z
    public int amount; // ���������� ����������� ��������




    [ContextMenu("�����")]
    public override void Use()
    {
        for (int i = 0; i < amount; i++)
        {
            // �������� �������
            GameObject go = Instantiate(prefab);

            go.transform.position = transform.position + new Vector3(0, 0, spacing * i);
        }
    }


}
