using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public bool enable;
    public AudioClip sound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = sound;
    }

    // Update is called once per frame
    void Update()
    {
        if(enable)
        {
            audioSource.Play();
        }
    }
}
