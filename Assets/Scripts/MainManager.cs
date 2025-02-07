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
    
    void Start()
    {
        nameText.text = $"Name: {GameManager.Instance?.GetPlayerName()}";
    }

    void Update() {
        
    }

    
    void FixedUpdate()
    {
        scoreText.text = $"Score: {GameManager.Instance?.GetPlayerScore()}";

        if(GameManager.Instance.GameOver)
        {
            gameOverCanvas.SetActive(true);
            finalScoreText.SetText($"Score: {GameManager.Instance.GetPlayerScore()}");
        }
    }
}
