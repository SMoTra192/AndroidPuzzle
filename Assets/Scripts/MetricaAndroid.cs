using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;
using YMMJSONUtils;

public class MetricaAndroid : MonoBehaviour
{
    private YandexAppMetricaConfig _config;
    private void level_start()
    {
        AppMetrica.Instance.ActivateWithConfiguration(_config);
    }
    
}

