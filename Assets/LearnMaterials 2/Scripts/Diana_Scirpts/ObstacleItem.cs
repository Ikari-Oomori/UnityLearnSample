using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [SerializeField] private float health = 1.0f;
   
    public UnityEvent onDestroyObstacle = new UnityEvent();

    private void Start()
    {
      renderer = GetComponent<Renderer>();
    }
    private Renderer renderer;
    public void TakeDamage(float damage)
    {
        Debug.Log("Obstact was hit");
        health -= damage;

        // Плавный переход цвета
        var color = renderer.material.color;
        color.a = Mathf.Lerp(1.0f, 0.0f, health);
        renderer.material.color = color;

        if (health <= 0)
        {
            onDestroyObstacle.Invoke();
            Destroy(gameObject); 
        }
    }
}
