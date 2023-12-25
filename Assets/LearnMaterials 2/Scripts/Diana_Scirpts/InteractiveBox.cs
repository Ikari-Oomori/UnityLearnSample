using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
   public InteractiveBox next;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Transparent/Diffuse"));
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
    }

    public void AddNext(InteractiveBox newNext)
    {
        next = newNext;     
    }
    private void FixedUpdate()
    {
         if (next != null)
         {
            if (Physics.Raycast(transform.position, next.transform.position - transform.position, out RaycastHit hit, 10000 ))
            {
                if (hit.collider.GetComponent<ObstacleItem>() != null )
                {
                    hit.collider.GetComponent<ObstacleItem>().TakeDamage(Time.deltaTime);
                }
                lineRenderer.SetPosition(1, hit.point);
                Debug.DrawRay(transform.position, hit.point - transform.position, Color.red, Mathf.Infinity);
            }
            else
            {
                lineRenderer.SetPosition(1, next.transform.position);
                Debug.DrawRay(transform.position, next.transform.position - transform.position, Color.red, Mathf.Infinity);
            }
         }
      
    }
}
