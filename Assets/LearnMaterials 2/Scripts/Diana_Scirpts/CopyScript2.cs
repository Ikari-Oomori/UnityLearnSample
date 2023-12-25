using UnityEngine;

public class SimpleCloneScript : SampleScript2
{
    public GameObject objectToClone; // Объект для клонирования
    public float cloneSpacing; // Расстояние между клонами по оси Z
    public int numberOfClones; // Количество создаваемых клонов

    [ContextMenu("Создать Клоны")]
    public override void Use()
    {
        for (int i = 0; i < numberOfClones; i++)
        {
            GameObject clone = Instantiate(objectToClone, transform.position + new Vector3(0, 0, cloneSpacing * i), Quaternion.identity);
        }
    }
}
