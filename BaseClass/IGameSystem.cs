public abstract class IGameSystem
{
    protected GameFacade mGameFacade;
    // 抽象类是为基类而生的，virtual是多态的应用
    public virtual void Init()
    {
        mGameFacade = GameFacade.Instance;
    }

    public virtual void Update()
    {}

    public virtual void Release()
    {}
}