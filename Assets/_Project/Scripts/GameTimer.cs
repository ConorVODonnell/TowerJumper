using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    float timeSinceLastJump;
    [SerializeField] UIManager ui;

    void Update() {
        UpdateTimer();
    }

    void UpdateTimer() {
        AddTime();
        ui.UpdateTimer(timeSinceLastJump);
    }

    void AddTime() {
        timeSinceLastJump += Time.deltaTime;
    }

    public void OnJump() {
        ResetTimer();
    }

     void ResetTimer() {
        timeSinceLastJump = 0;
        ui.UpdateTimer(timeSinceLastJump);
    }
}
