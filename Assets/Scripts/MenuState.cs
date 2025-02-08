using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// INHERITANCE
class MenuState : GameState
{
    GameObject playerNameInput;
    GameManager context;
    public MenuState(GameManager context)
    {
        Name = "MENU";
        this.context = context;
    }

    // POLYMORPHISM
    public override void Enter()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public override void Update()
    {

    }

    // POLYMORPHISM
    public override void Exit()
    {
        ResetPlayerInfo();
    }

    private string GetPlayerNameFromInput()
    {
        playerNameInput = GameObject.Find("PlayerNameInput");
        if (playerNameInput == null)
        {
            return context == null ? "Guest" : context.PlayerName;
        }
        return playerNameInput.GetComponent<TMP_InputField>().text.ToString();
    }

    public void ResetPlayerInfo()
    {
        string playerName = GetPlayerNameFromInput();
        context.Score = 0;
        context.PlayerName = playerName.Length > 0 ? playerName : "Guest";
    }
}
