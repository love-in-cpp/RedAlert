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

    public AchievenmentMemento CreateMemento()
    {
        // PlayerPrefs.SetInt("EnemyKilledCount", enemyKilledCount);
        // PlayerPrefs.SetInt("SoldierKilledCount", soldierKilledCount);
        // PlayerPrefs.SetInt("MaxStageLv", maxStageLv);
        AchievenmentMemento memento = new AchievenmentMemento();
        memento.enemyKilledCount = mEnemyKilledCount;
        memento.soldierKilledCount = mSoldierKilledCount;
        memento.maxStageLv = mMaxStageLv;
        return memento;
    }

    public void SetMemento(AchievenmentMemento memento)
    {
        // enemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
        // soldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
        // maxStageLv = PlayerPrefs.GetInt("MaxStageLv");
        mEnemyKilledCount = memento.enemyKilledCount;
        mSoldierKilledCount = memento.soldierKilledCount;
        mMaxStageLv = memento.maxStageLv;
    }
    public override void Init()
    {
        base.Init();
        mGameFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverAchievement(this));
        mGameFacade.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverAchievement(this));
        mGameFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverAchievement(this));
    }

    public override void Update()
    {
        
    }

    public override void Release()
    {
        
    }
}