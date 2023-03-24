using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int levelNumber;

    private void Awake()
    {
        levelNumber = (SceneManager.GetActiveScene().buildIndex) + 1;
    }

    

    public void ClickNextLevel()
    {
        SceneManager.LoadScene(levelNumber);
    }

}
