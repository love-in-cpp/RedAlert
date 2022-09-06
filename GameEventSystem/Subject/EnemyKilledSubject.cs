public class EnemyKilledSubject:IGameEventSubject
{
    private int mKilledCount = 0;
    public int killedCount
    {
        get { return mKilledCount; }
    }

    public override void Notify()
    {
        mKilledCount++;
        base.Notify();
    }
}