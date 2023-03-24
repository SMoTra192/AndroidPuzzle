using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    private Button _button;
    private void Awake()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(onClick);
    }

    public void onClick()
    {
        int button = gameObject.transform.GetSiblingIndex() + 2;
        int completeLevel = PlayerPrefs.GetInt("LevelValue");
        if(button < completeLevel + 1) SceneManager.LoadScene(button);
    }
}
