using System.Collections;
using UnityEngine;

public class RotateScript : SampleScript2
{
    [SerializeField]
    float rotationSpeed = 10f; // скорость вращения объекта

    [SerializeField]
    float rotationAngleX = 90f; // угол вращения вокруг оси X

    [SerializeField]
    float rotationAngleY = 0f; // угол вращения вокруг оси Y

    [SerializeField]
    float rotationAngleZ = 0f; // угол вращения вокруг оси Z

    IEnumerator RotateCoroutine()
    {
        float t = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(
            startRotation.eulerAngles.x + rotationAngleX,
            startRotation.eulerAngles.y + rotationAngleY,
            startRotation.eulerAngles.z + rotationAngleZ
        );

        while (t < 1)
        {
            t += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        transform.rotation = targetRotation;
    }

    [ContextMenu("Вращение")]
    public override void Use()
    {
        StartCoroutine(RotateCoroutine());
    }
}
