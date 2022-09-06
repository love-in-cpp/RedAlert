public class EnemyKilledObserverAchievement:IGameEventObserver
{
    // private EnemyKilledSubject mSubject;
    private AchievementSystem mAchSystem;

    public EnemyKilledObserverAchievement(AchievementSystem system)
    {
        mAchSystem = system;
    }
    public override void Update()
    {
        mAchSystem.AddEnemyKilledCount();
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        // mSubject = sub as EnemyKilledSubject;
    }
    
}