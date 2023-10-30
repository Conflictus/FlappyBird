using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topBorder : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Размещаем объект на верхней границе камеры
        PlaceObjectOnTop();
    }

    void Update()
    {
        // Вызываем PlaceObjectOnTop() каждый кадр, если камера двигается или изменяет размер
        PlaceObjectOnTop();
    }

    void PlaceObjectOnTop()
    {
        if (mainCamera != null)
        {
            // Получаем позицию камеры
            Vector3 cameraPosition = mainCamera.transform.position;

            // Вычисляем новую позицию для объекта так, чтобы его верхняя граница совпадала с верхней границей камеры
            float objectHeight = spriteRenderer.bounds.size.y;
            Vector3 newPosition = new Vector3(transform.position.x, cameraPosition.y + mainCamera.orthographicSize + (objectHeight / 2), transform.position.z);

            // Применяем новую позицию объекту
            transform.position = newPosition;
        }
    }
}
