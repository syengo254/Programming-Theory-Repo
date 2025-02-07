using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public static GameManager Instance { get; private set; }

    IGameState currentGameState;
    IGameState defaultGameState;

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

    private void Update() {
        currentGameState.StateUpdate();
    }

    public void StartGame()
    {
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
