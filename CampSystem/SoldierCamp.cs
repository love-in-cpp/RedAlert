using UnityEngine;

public class SoldierCamp:ICamp
{
    private int mLv = 1;
    private const int MAX_LV = 4;
    private WeaponType mWeaponType = WeaponType.Gun; // 利用枚举类型的自增完成升级


    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime, WeaponType weaponType = WeaponType.Gun, int lv = 1) 
        : base(gameObject, name, icon, soldierType, position, trainTime)
    {
        mLv = lv;
        mWeaponType = weaponType;
    }

    public override int lv
    {
        get { return mLv; }
    }

    public override WeaponType weaponType
    {
        get { return mWeaponType; }
    }

    public override void Train()
    {
        // 添加训练命令
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType, mWeaponType, mPosition, mLv);
        mCommands.Add(cmd);
    }
}