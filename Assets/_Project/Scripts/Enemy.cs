using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : WalkingCreature
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] float minWaitTime = 1;
    [SerializeField] float maxWaitTime = 3;


    void Start() {
        StartCoroutine(RandomDirection());
    }

    IEnumerator RandomDirection() {
        while (true) {
            yield return new WaitForSeconds(RandomWaitTime());
            ChangeDirection();
        }
    }

    private float RandomWaitTime() {
        return Random.Range(minWaitTime, maxWaitTime);
    }

    void Update() {
        AutoMove();
    }

    void AutoMove() {
        tf.position += MoveVector();
    }

    Vector3 MoveVector() {
        var moveVector = new Vector3(HorizontalMovement(), 0, 0);

        return moveVector * Time.deltaTime;
    }

    float HorizontalMovement() {
        return horizontalSpeed * direction;
    }
}
