using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitS : MonoBehaviour
{
    AudioSource audiosource;    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

    }
    public void playSoud()
    {
        audiosource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
