using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InHeatController : MonoBehaviour
{
    [SerializeField] ButtplugClient client = null;
    [SerializeField] Slider intensitySlider = null;
    [SerializeField] Slider frequencySlider = null;

    float sendTimer = 0f;
    float sendTimerPeriod = .15f;

    void Update()
    {
        sendTimer += Time.deltaTime;
        if (sendTimer >= sendTimerPeriod)
        {
            sendTimer = 0f;
            var value = intensitySlider.value;
            value *= Mathf.Pow(Mathf.Sin(frequencySlider.value * Time.realtimeSinceStartup), 2);
            client.SendValue(value);
        }
    }
}
