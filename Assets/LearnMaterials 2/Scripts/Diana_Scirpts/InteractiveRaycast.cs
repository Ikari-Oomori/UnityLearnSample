using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject prefab;
    private InteractiveBox selectedBox;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleLeftClick();
        }

        if (Input.GetMouseButtonDown(1))
        {
            HandleRightClick();
        }
    }

    void HandleLeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("InteractivePlane"))
            {
                CreateInteractiveBox(hit.point);
            }
            else if (hit.collider.GetComponent<InteractiveBox>() != null)
            {
                SelectInteractiveBox(hit.collider.GetComponent<InteractiveBox>());
            }
        }
    }

    void HandleRightClick()
    {
        if (selectedBox != null)
        {
            DestroyInteractiveBox(selectedBox);
        }
    }

    void CreateInteractiveBox(Vector3 position)
    {
        GameObject boxObject = Instantiate(prefab, position, Quaternion.identity);
        InteractiveBox interactiveBox = boxObject.GetComponent<InteractiveBox>();

        if (interactiveBox != null)
        {
            // Добавляем логику для установки next, если у нас уже есть выбранный объект
            if (selectedBox != null)
            {
                selectedBox.AddNext(interactiveBox);
            }
        }
    }

    void SelectInteractiveBox(InteractiveBox box)
    {
        selectedBox = box;
    }

    void DestroyInteractiveBox(InteractiveBox box)
    {
        if (box != null)
        {
            Destroy(box.gameObject);
            selectedBox = null;
        }
    }
}
