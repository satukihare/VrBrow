using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusControllerVibrate : MonoBehaviour
{
    static private bool bLShock;
    static private bool bRShock;

    static private float TimeshockL;
    static private float TimeshockR;

    static private float TimeshockLStart;
    static private float TimeshockRStart;

    static private float frequencyL;
    static private float frequencyR;

    static private float amplitudeL;
    static private float amplitudeR;
    

    // Start is called before the first frame update
    void Start()
    {
        bLShock = false;
        bRShock = false;
        TimeshockL = 0.0f;
        TimeshockR = 0.0f;
        TimeshockLStart = 0.0f;
        TimeshockRStart = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(bLShock)
        {
            VibrateLShock();
        }

        if(bRShock)
        {
            VibrateRShock();
        }

    }

    private void VibrateLShock()
    {
        if (Time.time - TimeshockLStart <= TimeshockL)
        {
            OVRInput.SetControllerVibration(frequencyL, amplitudeL/* * Mathf.Sin((Time.time - TimeshockLStart) * 90)*/, OVRInput.Controller.LTouch);
        }
        else
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            bLShock = false;
            TimeshockLStart = 0.0f;
        }
    }

    private void VibrateRShock()
    {
        if (Time.time - TimeshockRStart <= TimeshockR)
        {
            OVRInput.SetControllerVibration(frequencyR, amplitudeR/* * Mathf.Sin((Time.time - TimeshockRStart) * 90)*/, OVRInput.Controller.RTouch);
        }
        else
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            bRShock = false;
            TimeshockRStart = 0.0f;
        }
    }

    static public void SetVibrateL(float TimeShock, float frequency, float amplitude)
    {
        bLShock = true;
        TimeshockL = TimeShock;
        TimeshockLStart = Time.time;
        frequencyL = frequency;
        amplitudeL = amplitude;

    }

    static public void SetVibrateR(float TimeShock, float frequency, float amplitude)
    {
        bRShock = true;
        TimeshockR = TimeShock;
        TimeshockRStart = Time.time;
        frequencyR = frequency;
        amplitudeR = amplitude;
    }
}
