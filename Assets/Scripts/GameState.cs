public abstract class GameState
{
    public string Name;
    
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
