public class SoldierKilledSubject:IGameEventSubject
{
    private int mKilledCount = 0;
    public int killedCount => mKilledCount;

    public override void Notify()
    {
        mKilledCount++;
        base.Notify();
    }
}