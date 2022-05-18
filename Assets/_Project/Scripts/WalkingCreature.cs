using System;
using UnityEngine;

public class WalkingCreature : MonoBehaviour
{
    protected Transform tf;
    protected int direction = 1;

    void Awake() {
        tf = GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Wall"))
            HitWall();
    }

    protected virtual void HitWall() {
        DirectTowardsCenter();
    }

    protected void DirectTowardsCenter() {
        direction = -Math.Sign(tf.localPosition.x);
    }

    protected void ChangeDirection() {
        direction = -direction;
    }
}