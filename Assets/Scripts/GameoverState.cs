using UnityEngine;

// INHERITANCE
class GameoverState : GameState
{
    public GameoverState()
    {
        Name = "GAMEOVER";
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
    }
}