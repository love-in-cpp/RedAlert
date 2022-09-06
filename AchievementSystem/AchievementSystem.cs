using System;

public class AchievementSystem : IGameSystem
{
    // 本成就系统只保存一些最大数据
    private int mEnemyKilledCount = 0;
    private int mSoldierKilledCount = 0;
    private int mMaxStageLv = 1;

    public void AddEnemyKilledCount(int number = 1)
    {
        mEnemyKilledCount += number;
    }

    public void AddSoldierKilledCount(int number = 1)
    {
        mSoldierKilledCount += number;
    }

    public void SetMaxStageLv(int stageLv)
    {
        if (stageLv > mMaxStageLv)
        {
            mMaxStageLv = stageLv;
        }
    }
    
    public override void Init()
    {
        base.Init();
        mGameFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverAchievement(this));
    }

    public override void Update()
    {
        
    }

    public override void Release()
    {
        
    }
}