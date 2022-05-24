using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] Slider slider;
    [SerializeField] float maxTimeOnFloor = 6;

    void Awake() {
        slider.maxValue = maxTimeOnFloor;
    }

    public void UpdateTimer(float newTime) {
        timerText.text = newTime.ToString("00.0");
        UpdateSlider(newTime);
    }

    void UpdateSlider(float timeOnFloor) {
        slider.value = timeOnFloor;

    }
}
