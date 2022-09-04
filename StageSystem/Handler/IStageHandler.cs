
public abstract class IStageHandler
{
    protected int mLv; // 当前关卡
    protected IStageHandler mNextHandler;

    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }
    
    public void Handle(int level)
    {
        if (level == mLv)
        {
            UpdateStage();      
        }
        else
        {
            mNextHandler.Handle(level);
        }
        
    }
    protected virtual void UpdateStage() {}
}