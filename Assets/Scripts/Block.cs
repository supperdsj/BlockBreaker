﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
    }
}
