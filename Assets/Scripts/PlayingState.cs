using UnityEngine;
using UnityEngine.SceneManagement;

// INHERITANCE
class PlayingState : GameState
{
    public PlayingState()
    {
        Name = "PLAYING";
    }

    public override void Enter()
    {
        SceneManager.LoadScene(1);
    }

    public override void Update()
    {

    }

    public override void Exit()
    {

    }
}
