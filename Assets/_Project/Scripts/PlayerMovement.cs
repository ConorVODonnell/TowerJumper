using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform tf;

    [SerializeField] float horizontalSpeed;
    int direction = 1;

    void Awake() {
        tf = GetComponent<Transform>();
    }

    void Update() {
        AutoMove();
    }

    void AutoMove() {
        tf.position += MoveVector();
    }

    Vector3 MoveVector() {
        var moveVector = new Vector3(HorizontalMovement(), 0 ,0);

        return moveVector * Time.deltaTime;
    }

    float HorizontalMovement() {
        return horizontalSpeed * direction;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Wall"))
            HitWall();
    }

    void HitWall() {
        DirectTowardsCenter();
    }

    void DirectTowardsCenter() {
        direction = -Math.Sign(tf.position.x);
    }
}
