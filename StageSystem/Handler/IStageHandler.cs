
public abstract class IStageHandler
{
    protected int mLv; // 当前关卡
    protected IStageHandler mNextHandler;
    private int mCountToFinished;
    protected StageSystem mStageSystem;

    public IStageHandler(StageSystem stageSystem, int lv, int countToFinished)
    {
        mStageSystem = stageSystem;
        mLv = lv;
        mCountToFinished = countToFinished;
    }

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
            CheckIsFindshed(); // 检查关卡时候结束
        }
        else
        {
            mNextHandler.Handle(level);
        }
        
    }

    private void CheckIsFindshed()
    {
        if (mStageSystem.GetCountOfEnemyKilled() >= mCountToFinished)
        {
            
        }
    }

    protected virtual void UpdateStage() {}
}