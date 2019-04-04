using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;

    Level level;

    void Start() {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        FindObjectOfType<GameStatus>().AddToScore();
        level.BlockDestroyed();
        
        // AudioSource.PlayClipAtPoint(breakSound,Camera.main.transform.position);
        AudioSource.PlayClipAtPoint(breakSound,gameObject.transform.position);
        Destroy(gameObject);
    }
}
