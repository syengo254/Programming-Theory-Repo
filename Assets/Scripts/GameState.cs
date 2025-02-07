public abstract class GameState
{
    public string Name;
    public abstract void Enter();
    public virtual void StateUpdate() {}
    public virtual void Exit() {}
}
