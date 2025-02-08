using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI difficultyScoreText;

    public static MainManager Current { get; private set; }
    public int EvadedCount;
    private int evadedThreshold = 5;
    private int difficulty = 1;
    public int Difficulty
    {
        get
        {
            return difficulty;
        }
    }

    public GameObject gameOverCanvas;
    GameManager gameManager;
    bool gameEnded;

    private void Awake()
    {
        if (Current == null)
        {
            Current = this;
        }
    }

    void Start()
    {
        gameManager = GameManager.Instance;

        if (gameManager != null)
        {
            nameText.text = $"Name: {gameManager.GetPlayerName()}";
        }
        difficultyScoreText.text = $"Difficulty: {Difficulty}";
    }

    void Update()
    {
        if (gameEnded) return;

        if (EvadedCount >= evadedThreshold)
        {
            EvadedCount = 0;
            IncrementDifficulty();
            evadedThreshold += 5;
        }
    }

    void IncrementDifficulty()
    {
        difficulty++;
        difficultyScoreText.text = $"Difficulty: {Difficulty}";
    }

    void FixedUpdate()
    {
        if (gameEnded) return;

        scoreText.text = $"Score: {gameManager.GetPlayerScore()}";

        if (gameManager.GameOver)
        {
            gameOverCanvas.SetActive(true);
            finalScoreText.SetText($"Score: {gameManager.GetPlayerScore()}");
            gameEnded = true;
        }
    }

    public void HandleMenuButton()
    {
        gameManager.ShowMenu();
    }

    public void HandleRestartGameButton()
    {
        gameManager.StartGame();
    }
}
