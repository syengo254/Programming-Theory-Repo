using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public static GameManager Instance { get; private set; }

    GameState currentState;
    PlayingState playingState;
    MenuState menuState;
    GameoverState gameoverState;

    // ENCAPSULATION
    public GameState CurrentGameState
    {
        get
        {
            return currentState;
        }
        set{
            if(value == null)
            {
                Debug.LogError("Game state cannot be set to null!");
            }
            else
            {
                currentState = value;
            }
        }
    }

    public string PlayerName;
    public int Score;

    public bool GameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            menuState = new MenuState(this);
            playingState = new PlayingState();
            gameoverState = new GameoverState(this);

            CurrentGameState = menuState;
            ShowMenu();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        CurrentGameState.Update();
    }

    public void StartGame()
    {
        SwitchGameState(playingState);
    }

    //ABSTRACTION
    public void ShowMenu()
    {
        SwitchGameState(menuState);
    }

    public void SetGameOver()
    {
        SwitchGameState(gameoverState);
    }

    private void SwitchGameState(GameState newState)
    {
        CurrentGameState.Exit();
        CurrentGameState = newState;
        CurrentGameState.Enter();
    }

    public int GetPlayerScore()
    {
        return Score;
    }

    public string GetPlayerName()
    {
        return PlayerName;
    }

    public void AddPlayerScore(int points)
    {
        Score += points;
    }

    private string GetPlayerNameFromInput()
    {
        GameObject playerNameInput = GameObject.Find("PlayerNameInput");
        if (playerNameInput == null)
        {
            return PlayerName == "" ? "Guest" : PlayerName;
        }
        return playerNameInput.GetComponent<TMP_InputField>().text.ToString();
    }

    public void ResetPlayerInfo()
    {
        string playerName = GetPlayerNameFromInput();
        Score = 0;
        PlayerName = playerName.Length > 0 ? playerName : "Guest";
    }
}
