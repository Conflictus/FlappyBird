using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    
    public float scrollSpeed = 1.0f;
    private Rigidbody2D rb2d;
    private float width;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
         rb2d.velocity = new Vector2(-Mathf.Abs(scrollSpeed), 0); 
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        if (transform.position.x < -width)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }

}
