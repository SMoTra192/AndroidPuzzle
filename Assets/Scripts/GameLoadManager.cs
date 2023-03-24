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
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt ("Level", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("AppLoad",0);
    }
}
