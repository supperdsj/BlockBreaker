using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] int timesHit = 0;
    [SerializeField] Sprite[] hitSprites;
    Level level;

    void Start() {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") {
            level.CountBreakableBlocks();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            timesHit++;
            if (timesHit >= maxHits) {
                DestroyBlock();
            }
            else {
                ShowNextHitSprite();
            }
        }
    }

    void ShowNextHitSprite() {
        if (hitSprites[timesHit - 1] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
        else {
            GetComponent<SpriteRenderer>().sprite = hitSprites[hitSprites.Length - 1];
        }
    }

    void DestroyBlock() {
        FindObjectOfType<GameStatus>().AddToScore();
        level.BlockDestroyed();

        // AudioSource.PlayClipAtPoint(breakSound,Camera.main.transform.position);
        AudioSource.PlayClipAtPoint(breakSound, gameObject.transform.position);
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(sparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}