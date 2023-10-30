using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip soundClip; 
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                audioSource.Play();
        }
        
    }
}
