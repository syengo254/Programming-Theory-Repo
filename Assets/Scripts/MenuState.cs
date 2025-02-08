using UnityEngine.SceneManagement;

// INHERITANCE
class MenuState : GameState
{
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
        context.ResetPlayerInfo();
    }
}
