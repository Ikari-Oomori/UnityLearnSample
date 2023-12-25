using System.Collections;
using UnityEngine;

public class RotateScript : SampleScript2
{
    [SerializeField]
    float rotationSpeed = 10f; // �������� �������� �������

    [SerializeField]
    float rotationAngleX = 90f; // ���� �������� ������ ��� X

    [SerializeField]
    float rotationAngleY = 0f; // ���� �������� ������ ��� Y

    [SerializeField]
    float rotationAngleZ = 0f; // ���� �������� ������ ��� Z

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

    [ContextMenu("��������")]
    public override void Use()
    {
        StartCoroutine(RotateCoroutine());
    }
}
