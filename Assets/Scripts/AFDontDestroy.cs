using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFDontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
