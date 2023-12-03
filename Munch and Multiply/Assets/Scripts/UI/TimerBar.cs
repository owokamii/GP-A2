using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider timerBarSlider;

    public void SetMaxTimer(float time)
    {
        timerBarSlider.maxValue = time;
        timerBarSlider.value = time;
    }

    public void SetTimer(float time)
    {
        timerBarSlider.value = time;
    }
}
