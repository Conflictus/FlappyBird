using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banner : MonoBehaviour
{
    public float speed = 2.0f; 
    private Vector2 targetPosition;
    void Start()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        // Преобразуем центр экрана в мировые координаты
        targetPosition = new Vector2(0,0);

        // Устанавливаем начальную позицию объекта выше экрана
        
    }
    public void MoveDown() {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
