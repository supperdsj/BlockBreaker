using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
     // Debug.Log(collision);   
        // throw new System.NotImplementedException();
        SceneManager.LoadScene("GameOver");
    }
}
