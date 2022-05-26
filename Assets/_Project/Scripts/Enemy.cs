using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : WalkingCreature, IPunchable
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] float minWaitTime = 1;
    [SerializeField] float maxWaitTime = 3;

    [SerializeField] bool goRight, goLeft;

    void Start() {
        StartCoroutine(RandomDirection());
    }

    IEnumerator RandomDirection() {
        while (true) {
            yield return new WaitForSeconds(RandomWaitTime());
            //ChangeDirection();
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
        if (goRight) direction = 1;
        if (goLeft) direction = -1;
        return horizontalSpeed * direction;
    }

    public void GetPunched() {
        print("You just hit me!");
    }
}
