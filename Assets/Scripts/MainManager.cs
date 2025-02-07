using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    
    void Start()
    {
        nameText.text = $"Name: {GameManager.Instance.GetPlayerName()}";
    }

    void Update() {
        
    }

    
    void FixedUpdate()
    {
        scoreText.text = $"Score: {GameManager.Instance.GetPlayerScore()}";
    }
}
