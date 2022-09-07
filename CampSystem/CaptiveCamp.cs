using UnityEngine;

public class CaptiveCamp:ICamp
{
    private WeaponType mWeaponType = WeaponType.Gun; // 利用枚举类型的自增完成升级
    private EnemyType mEnemyType;
    
    public CaptiveCamp(GameObject gameObject, string name, string icon, EnemyType enemyType, Vector3 position, float trainTime)
        : base(gameObject, name, icon, SoldierType.Captive, position, trainTime)
    {
        mEnemyType = enemyType;
        energyCostStragy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }

    public override int lv => 1;
    public override WeaponType weaponType => mWeaponType;
    public override int energyCostCampUpgrade => 0;
    public override int energyCostWeaponUpgrade => 0;
    public override int energyCostTrain => mEnergyCostTrain;
    protected override void UpdateEnergyCost()
    {
        mEnergyCostTrain = energyCostStragy.GetSoldierTrainCost(mSoldierType, lv);
    }

    public override void Train()
    {
        TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType, mWeaponType, mPosition, lv);
        mCommands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        return;
    }

    public override void UpgradeWeapon()
    {
        return;
    }
}