using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject parentOfPoolItems;
    private float childCount,maxChildCount;

    private void Awake()
    {
        maxChildCount = parentOfPoolItems.transform.childCount;
        
        
    }

    private void Update()
    {
        childCount = parentOfPoolItems.transform.childCount;
        //print(Math.Abs(childCount - maxChildCount));
        _slider.value = (Math.Abs(childCount - maxChildCount) / maxChildCount);
    }
}
