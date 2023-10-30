using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Transform column;
    [SerializeField] float maxHeight;
    GameManager gm;
    public AudioSource score;
    public AudioSource hit;
    bool flag = false;
    // Start is called before the first frame update
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        AudioSource[] audioSources = gameObject.GetComponentsInChildren<AudioSource>();
        score = audioSources[0];
        hit = audioSources[1];
        float height = Random.Range(-maxHeight, maxHeight);
        column.position = new Vector2(gm.topRight.x, column.position.y+height);
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    { 
        if (collision.CompareTag("player")) 
        { 
            
            hit.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {   if (gm.Move == false) {

    
        transform.position += Vector3.left * speed *Time.deltaTime;
        if (transform.position.x < -1 && flag == false) {
            flag = true;
            gm.Score++;
            PlayerPrefs.SetInt("Best", gm.best);
            PlayerPrefs.Save();
            score.Play();
        }
        if (transform.position.x > gm.BottomLeft.x - 5*transform.localScale.x  )
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        else Destroy(gameObject);
    }
    }
    }
