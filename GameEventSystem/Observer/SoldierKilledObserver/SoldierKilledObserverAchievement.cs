public class SoldierKilledObserverAchievement:IGameEventObserver
{
    private AchievementSystem mAchiSystem;

    public SoldierKilledObserverAchievement(AchievementSystem system)
    {
        mAchiSystem = system;
    }
    public override void Update()
    {
        mAchiSystem.AddSoldierKilledCount();
    }

    public override void SetSubject(IGameEventSubject sub)
    {
    }
}