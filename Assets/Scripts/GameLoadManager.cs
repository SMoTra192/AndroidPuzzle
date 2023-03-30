using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadManager : MonoBehaviour
{
    void Start() 
    {  
    }

    private void level_start()
    {
        int level_number = SceneManager.GetActiveScene().buildIndex - 1;
        string level_name = $"{level_number}_{SceneManager.GetActiveScene().name}";
        int level_count = PlayerPrefs.GetInt("level_count");
        PlayerPrefs.SetInt("level_count",level_count + 1);
        level_loop
        
    }
    void OnApplicationQuit()
    {
        
        AppMetrica.Instance.SendEventsBuffer();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        AppMetrica.Instance.SendEventsBuffer();
    }
}
