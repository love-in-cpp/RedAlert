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
}