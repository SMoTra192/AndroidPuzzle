using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadManager : MonoBehaviour
{
    void Start() 
    {  PlayerPrefs.SetInt ("Level", SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.GetInt("AppLoad") == 0)
        {
            PlayerPrefs.SetInt("AppLoad",1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
            PlayerPrefs.SetInt("LevelValue",2);
        }
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
        PlayerPrefs.SetInt ("Level", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("AppLoad",0);
        AppMetrica.Instance.SendEventsBuffer();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        AppMetrica.Instance.SendEventsBuffer();
    }
}
