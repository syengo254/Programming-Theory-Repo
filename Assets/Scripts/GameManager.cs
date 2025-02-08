using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public static GameManager Instance { get; private set; }

    GameObject playerNameInput;
    private GameState gameState;
    GameState defaultGameState;

    // ENCAPSULATION
    public GameState CurrentGameState
    {
        get
        {
            return gameState;
        }
        set{
            if(value == null)
            {
                Debug.LogError("Game state cannot be set to null!");
            }
            else
            {
                gameState = value;
            }
        }
    }
    private PlayerInfo playerInfo;

    public bool GameOver { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            defaultGameState = new MenuGameState(); // default start state
            ShowMenu();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        CurrentGameState.StateUpdate();
    }

    private string GetPlayerNameFromInput()
    {
        playerNameInput = GameObject.Find("PlayerNameInput");
        if(playerNameInput == null)
        {
            return playerInfo == null ? "Guest" : playerInfo.Name;
        }
        return playerNameInput.GetComponent<TMP_InputField>().text.ToString();
    }

    public void StartGame()
    {
        ResetPlayerInfo();
        SwitchGameState(new PlayingGameState());
    }

    //ABSTRACTION
    public void ShowMenu()
    {
        SwitchGameState(defaultGameState);
    }

    public void SetGameOver()
    {
        GameOver = true;
        SwitchGameState(new GameOverGameState());
    }

    private void SwitchGameState(GameState newState)
    {
        CurrentGameState?.Exit();
        CurrentGameState = newState;
        CurrentGameState.Enter();
    }

    public int GetPlayerScore()
    {
        return playerInfo.Score;
    }

    public string GetPlayerName()
    {
        return playerInfo.Name;
    }

    public void ResetPlayerInfo()
    {
        string playerName = GetPlayerNameFromInput();
        playerInfo = new PlayerInfo
        {
            Score = 0,
            Name = playerName.Length > 0 ? playerName : "Guest",
        };
    }

    public void AddPlayerScore(int points)
    {
        playerInfo.Score += points;
    }

    class PlayerInfo
    {
        public string Name;
        public int Score;
    }

    // state classes
    // INHERITANCE
    class MenuGameState : GameState
    {
        public MenuGameState()
        {
            Name = "MENU";
        }

        // POLYMORPHISM
        public override void Enter()
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
            }
        }

        public override void Exit()
        {
            print($"Exited {this.Name} STATE...");
        }
    }

    class PlayingGameState : GameState
    {
        public PlayingGameState()
        {
            Name = "PLAYING";
        }

        public override void Enter()
        {
            SceneManager.LoadScene(1);
        }

        public override void Exit()
        {
            print($"Exited {this.Name} STATE...");
        }
    }

    class GameOverGameState : GameState
    {
        public GameOverGameState()
        {
            Name = "GAMEOVER";
        }

        public override void Enter()
        {
            print("Game over!");
        }

        public override void Exit()
        {
            GameManager.Instance.GameOver = false;
            print($"Exited {this.Name} STATE...");
        }
    }
}
