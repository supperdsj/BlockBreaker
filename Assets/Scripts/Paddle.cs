using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField] float screenWidthInUnits = 0;
    [SerializeField] float unitSize = 0;

    // Update is called once per frame
    void Update() {
        // Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        Vector2 paddlePosition =
            new Vector2(Input.mousePosition.x / Screen.width * screenWidthInUnits, transform.position.y);
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, unitSize, screenWidthInUnits - unitSize);
        transform.position = paddlePosition;
    }
}