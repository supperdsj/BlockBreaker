using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Ball : MonoBehaviour {
    [SerializeField] Paddle paddle = null;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    Vector2 paddleToBallVector;
    bool hasStarted;

    void Start() {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    void Update() {
        if (!hasStarted) {
            LaunchOnMouseClick();
            LockBallToPaddle();
        }
    }

    void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}