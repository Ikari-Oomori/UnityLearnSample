using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MoveScript2 : SampleScript2
{
    // Start is called before the first frame update


    [SerializeField]
    float speed = 1f; // скорость перемещения объекта

    [SerializeField]
    Vector3 targetPosition; // целевая позиция

    // Update is called once per frame

    IEnumerator MoveCorotine()
    {
        float T;
        T = 0;
        Vector3 startposition = transform.position;
        while (true)
        {

            T += Time.deltaTime * speed;


            // перемещение объекта на пройденное расстояние вдоль вектора к целевой позиции
            transform.position = Vector3.Lerp(startposition, targetPosition, T);
            yield return null;
            if (T >= 1) // если объект достиг целевой позиции
            {
                transform.position = targetPosition;
                break;
            }
        }
    }

    [ContextMenu("переместить")]
    public override void Use()
    {
        StartCoroutine(MoveCorotine());
    }
}
