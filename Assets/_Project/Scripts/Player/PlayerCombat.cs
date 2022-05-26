using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour
{
    public int Punches { get; private set; }
    [SerializeField] int startingPunches;
    public UnityEvent<int> punchesChangedEvent;

    void Awake() {
        UpdatePunches(startingPunches);
    }

    public void AddPunch() {
        AddPunch(1);
    }
    public void SubtractPunch() {
        AddPunch(-1);
    }
    public void AddPunch(int amountToAdd) {
        UpdatePunches(Punches + amountToAdd);
    }

    void UpdatePunches(int newPunchCount) {
        Punches = newPunchCount;
        punchesChangedEvent.Invoke(Punches);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            RunIntoEnemy(collision.GetComponent<Enemy>());
        }
    }

    void RunIntoEnemy(Enemy enemy) {
        TryPunch(enemy);
    }

    void TryPunch(Enemy enemy) {
        var punchable = enemy as IPunchable;
        if (punchable == null) return;

        if (CanPunch())
            Punch(punchable);
    }

    bool CanPunch() {
        if (Punches > 0) return true;

        return false;
    }

    void Punch(IPunchable enemy) {
        UpdatePunches(--Punches);
        enemy.GetPunched();
    }
}