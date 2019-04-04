using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
    [Range(0.5f, 2f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePreBlockDestroyed = 100;
    [SerializeField] int currentScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] public bool isAutoPlayEnabled;


    void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        scoreText.text = currentScore.ToString();
    }

    void Update() {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() {
        currentScore += scorePreBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame() {
        Destroy(gameObject);
    }
}