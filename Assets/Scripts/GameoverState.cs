using UnityEngine;

// INHERITANCE
class GameoverState : GameState
{
    GameManager context;

    public GameoverState(GameManager context)
    {
        Name = "GAMEOVER";
        this.context = context;
    }

    public override void Enter()
    {
        GameManager.Instance.GameOver = true;
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        GameManager.Instance.GameOver = false;
        context.ResetPlayerInfo();
    }
}