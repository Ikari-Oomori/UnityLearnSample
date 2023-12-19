using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[HelpURL("https://docs.google.com/document/d/1RMamVxE-yUpSfsPD_dEa4-Ak1qu6NTo83qY1O4XLxUY/edit?usp=sharing")]
public class DestroyModule : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10f)]
    private float destroyDelay = 1.0f;

    [SerializeField, Range(1, 100)]
    private int minimalDestroyingObjectsCount = 10;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    public void ActivateModule()
    {
        StartCoroutine(DestroyRandomChildObjectCoroutine());
    }

    private IEnumerator DestroyRandomChildObjectCoroutine()
    {
        while (myTransform.childCount > minimalDestroyingObjectsCount)
        {
            int index = Random.Range(0, myTransform.childCount - 1);
            Destroy(myTransform.GetChild(index).gameObject);
            yield return new WaitForSeconds(destroyDelay);
        }
        Destroy(gameObject, Time.deltaTime);
    }

    // Контекстное меню для запуска удаления объектов
    [ContextMenu("Начать удаление объектов")]
    private void ContextMenuStartDestroyObjects()
    {
        Console.WriteLine("Начинаю удалять объекты");
        ActivateModule();
    }
}
