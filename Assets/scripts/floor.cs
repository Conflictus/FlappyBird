using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 2.0f;
    private Vector2 startPosition;
    GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        startPosition = transform.position;
    }

    private void Update()
    {  if (gm.Move == false) {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, 5); 
        transform.position = startPosition + Vector2.left * newPosition;
    }
    }
}
