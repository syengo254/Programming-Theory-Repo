using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;

    public static MainManager Current { get; private set; }
    private int difficulty = 1;
    public int Difficulty
    {
        get
        {
            return difficulty;
        }
    }
    
    public GameObject gameOverCanvas;
    bool gameEnded = false;
    GameManager gameManager;

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
        if (gameManager)
        {
            nameText.text = $"Name: {gameManager.GetPlayerName()}";
        }
    }

    void Update()
    {

    }


    void FixedUpdate()
    {
        if (gameEnded) return;

        scoreText.text = $"Score: {gameManager.GetPlayerScore()}";

        if (gameManager && gameManager.GameOver)
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
