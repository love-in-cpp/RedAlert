using UnityEngine;

public class NormalStageHandler:IStageHandler
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private int mCount;
    private Vector3 mPosition;
    

    protected override void UpdateStage()
    {
        base.UpdateStage();
    }

    public NormalStageHandler(StageSystem stageSystem, int lv, int countToFinished, EnemyType et, WeaponType wt, int count, Vector3 pos) : base(stageSystem, lv, countToFinished)
    {
        mEnemyType = et;
        mWeaponType = wt;
        mCount = count;
        mPosition = pos;
    }
}