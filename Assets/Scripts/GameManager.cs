using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public static GameManager Instance { get; private set; }

    GameObject playerNameInput;
    IGameState currentGameState;
    IGameState defaultGameState;
    private PlayerInfo playerInfo;

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
        currentGameState.StateUpdate();
    }

    private string GetPlayerNameFromInput()
    {
        playerNameInput = GameObject.Find("PlayerNameInput");
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

    private void SwitchGameState(IGameState newState)
    {
        currentGameState?.Exit();
        currentGameState = newState;
        currentGameState.Enter();
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

    struct PlayerInfo
    {
        public string Name;
        public int Score;
    }

    // state classes
    // POLYMORPHISM
    class MenuGameState : IGameState
    {
        public void Enter()
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
            }
        }

        public void StateUpdate()
        {
            // TODO
        }

        public void Exit()
        {
            // TODO: state cleanups
        }
    }

    class PlayingGameState : IGameState
    {
        public void Enter()
        {
            SceneManager.LoadScene(1);
        }

        public void StateUpdate()
        {
            // TODO
        }

        public void Exit()
        {
            // TODO: state cleanups
        }
    }
}
