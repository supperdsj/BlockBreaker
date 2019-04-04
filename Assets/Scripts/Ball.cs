using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Ball : MonoBehaviour {
    [SerializeField] Paddle paddle = null;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] float randomFactor = 0.2f;

    AudioSource myAudioSource;
    Vector2 paddleToBallVector;
    Rigidbody2D myRigidbody2D;

    bool hasStarted;

    void Start() {
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();

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
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    void OnCollisionEnter2D(Collision2D collision2d) {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));
        if (hasStarted) {
            AudioClip clip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}