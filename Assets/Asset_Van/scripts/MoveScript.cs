using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MoveScript : SampleScript
{
    // Start is called before the first frame update
    

    [SerializeField] 
    float speed = 1f; // �������� ����������� �������

    [SerializeField]
    Vector3 targetPosition; // ������� �������

    // Update is called once per frame

    IEnumerator MoveCorotine()
    {
        float T;
        T = 0;
        Vector3 startposition = transform.position;
        while (true)
        {

            T += Time.deltaTime * speed;


            // ����������� ������� �� ���������� ���������� ����� ������� � ������� �������
            transform.position = Vector3.Lerp(startposition, targetPosition, T);
            yield return null;
            if (T >= 1 ) // ���� ������ ������ ������� �������
            {
                transform.position = targetPosition;
                break;
            }
        }
    }

    [ContextMenu("�����������")]
    public override void Use() 
    {
        StartCoroutine(MoveCorotine());
    }
}
