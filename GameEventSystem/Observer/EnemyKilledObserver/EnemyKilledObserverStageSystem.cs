public class EnemyKilledObserverStageSystem:IGameEventObserver
{
    private EnemyKilledSubject mSubject;

    private StageSystem mStageSystem;
    public EnemyKilledObserverStageSystem(StageSystem ss)
    {
        mStageSystem = ss;
    }
    public override void Update()
    {
        mStageSystem.countOfEnemyKilled = mSubject.killedCount; // 观察主题发生变化然后把数据取出来给关卡系统

    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as EnemyKilledSubject; //基类转派生类，已知该基类引用的是派生类的实例 用as
    }
}