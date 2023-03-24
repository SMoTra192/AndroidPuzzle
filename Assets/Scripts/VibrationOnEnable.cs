using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationOnEnable : MonoBehaviour
{
    private void Awake()
    {
        Vibration.Init(); 
    }

    private void OnEnable()
    {
        int VibrationSet = PlayerPrefs.GetInt("VibrationEnabled");
        if(VibrationSet == 0)
        Vibration.VibrateAndroid(35);
    }
}
