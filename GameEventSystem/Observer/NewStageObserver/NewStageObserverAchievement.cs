public class NewStageObserverAchievement:IGameEventObserver
{
    private NewStageSubject mSubject;
    private AchievementSystem mAchiSystem;

    public NewStageObserverAchievement(AchievementSystem system)
    {
        mAchiSystem = system;
    }
    public override void Update()
    {
        mAchiSystem.SetMaxStageLv(mSubject.stageCount);
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as NewStageSubject;
    }
}