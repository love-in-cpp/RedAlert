public abstract class IGameEventObserver
{
    public abstract void Update();
    public abstract void SetSubject(IGameEventObserver sub);
}