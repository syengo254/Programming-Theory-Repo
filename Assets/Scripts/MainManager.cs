using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    public GameObject gameOverCanvas;
    bool gameEnded = false;
    
    void Start()
    {
        nameText.text = $"Name: {GameManager.Instance?.GetPlayerName()}";
    }

    void Update() {
        
    }

    
    void FixedUpdate()
    {
        if(gameEnded) return;
        
        scoreText.text = $"Score: {GameManager.Instance?.GetPlayerScore()}";

        if(GameManager.Instance && GameManager.Instance.GameOver)
        {
            gameOverCanvas.SetActive(true);
            finalScoreText.SetText($"Score: {GameManager.Instance.GetPlayerScore()}");
            gameEnded = true;
        }
    }
}
