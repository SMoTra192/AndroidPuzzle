using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadManager : MonoBehaviour
{
    private int level_number, level_count, level_loop;
    private string level_name,
        finish;

    private float timer;
    private bool level_random = false;
    private void sendEvent(string name,Dictionary<string,object> data)
    {
        AppMetrica.Instance.ReportEvent(name,data);
    }

    private void Awake()
    {
        level_start(level_number,level_name,level_count,level_loop,level_random);
    }

    void Start()
    {
        level_number = SceneManager.GetActiveScene().buildIndex - 1; print($"number_{level_number}"); 
        level_name = $"{level_number}_{SceneManager.GetActiveScene().name}"; print($"name_{level_name}");
        level_count = PlayerPrefs.GetInt("level_count"); print($"count_{level_count}"); 
        level_loop = PlayerPrefs.GetInt("level_loop");
        level_random = false;
    }

    public int levelNumber()
    {
        return level_number;
    }

    public string levelName()
    {
        return level_name;
    }

    public int levelCount()
    {
        return level_count;
    }

    public int levelLoop()
    {
        return level_loop;
    }

    public bool levelRandom()
    {
        return level_random;
    }

    public string levelFinish()
    {
        return finish;
    }
    public void level_start(int level_number,string level_name,int level_count,int level_loop,bool level_random)
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data["level_number"] = level_number;
        data["level_name"] = level_name;
        data["level_count"] = level_count;
        data["level_loop"] = level_loop;
        data["level_random"] = level_random;
        sendEvent("level_start",data);
        finish = "unfinished";
    }
    
    public void level_finish(int level_number,string level_name,int level_count,int level_loop,bool level_random,
        string finish)
    {
        print($"levelCount_{level_count}___LevelLoop{level_loop}");
        float timer = this.timer;
        Dictionary<string, object> data = new Dictionary<string, object>();
        data["level_number"] = level_number;
        data["level_name"] = level_name;
        data["level_count"] = level_count;
        data["level_loop"] = level_loop;
        data["level_random"] = level_random;
        data["result"] = finish;
        data["time"] = timer;
            sendEvent("level_finish",data);
    }

    
    void OnApplicationQuit()
    {
        finish = "game_closed";
        Dictionary<string, object> data = new Dictionary<string, object>();
        data["result"] = finish;
        sendEvent("gameQuit",data);
        AppMetrica.Instance.SendEventsBuffer();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        AppMetrica.Instance.SendEventsBuffer();
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }
}
