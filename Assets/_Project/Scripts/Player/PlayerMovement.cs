using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : WalkingCreature
{
    [SerializeField] float horizontalSpeed;

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

    public void OnJump() {
        HandleJumping();
    }

    void HandleJumping() {
        print("Jump!");
    }
}