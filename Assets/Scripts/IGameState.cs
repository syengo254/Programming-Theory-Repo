public interface IGameState
{
    public abstract void Enter();
    public void StateUpdate();
    public abstract void Exit();
}