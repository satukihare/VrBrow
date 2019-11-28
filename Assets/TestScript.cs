using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public bool enable = true;
    public AudioClip sound = null;
    public float loopTime = 0.1f;

    private AudioSource audioSource;
    private float time;
    private bool timerCheck;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = sound;
        time = 0;
        timerCheck = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enable && audioSource.clip != null && timerCheck)
        {
            audioSource.Play();
        }

        TimeManager();
    }

    void TimeManager()
    {
        if(time < loopTime)
        {
            timerCheck = false;
            time += Time.deltaTime;
        }
        else
        {
            timerCheck = true;
            time = 0;
        }
    }
}
