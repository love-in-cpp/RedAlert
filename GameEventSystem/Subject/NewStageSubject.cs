public class NewStageSubject:IGameEventSubject
{
    private int mStageCount = 1;
    public int stageCount => mStageCount;

    public override void Notify()
    {
        mStageCount++;
        base.Notify();
    }
}