using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField] float screenWidthInUnits = 0;
    [SerializeField] float unitSize = 0;

    // Update is called once per frame
    void Update() {
        transform.position = new Vector2(Mathf.Clamp(GetXPos(), unitSize, screenWidthInUnits - unitSize),
            transform.position.y);
        ;
    }

    float GetXPos() {
        if (FindObjectOfType<GameStatus>().isAutoPlayEnabled) {
            // return FindObjectOfType<Ball>().transform.position.x + UnityEngine.Random.Range(-0.3f * unitSize, 0.3f * unitSize);
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}