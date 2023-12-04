using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : SampleScript
{
    public GameObject prefab; // Префаб для создания
    public float spacing; // Расстояние между объектами по оси Z
    public int amount; // Количество создаваемых объектов




    [ContextMenu("Старт")]
    public override void Use()
    {
        for (int i = 0; i < amount; i++)
        {
            // Создание объекта
            GameObject go = Instantiate(prefab);

            go.transform.position = transform.position + new Vector3(0, 0, spacing * i);
        }
    }


}
