using System;
using UnityEngine;

public class TrainSoldierCommand:ITrainCommand
{
    private SoldierType mSoldierType;
    private WeaponType mWeaponType;
    private Vector3 mPosition;
    private int mLv;

    public TrainSoldierCommand(SoldierType st, WeaponType wt, Vector3 pos, int lv)
    {
        mSoldierType = st;
        mWeaponType = wt;
        mPosition = pos;
        mLv = lv;
    }
    public override void Execute()
    {
        switch (mSoldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.soldierFactory.CreatCharacter<SoldierRookie>(mWeaponType, mPosition, mLv);
                break;
            case SoldierType.Sergeant:
                FactoryManager.soldierFactory.CreatCharacter<SoldierSergeant>(mWeaponType, mPosition, mLv);
                break;
            case SoldierType.Captain:
                FactoryManager.soldierFactory.CreatCharacter<SoldierCaptain>(mWeaponType, mPosition, mLv);
                break;
            default:
                Debug.LogError("无法执行命令，无法根据SoldierType:"+mSoldierType+"创建角色");
                break;
        }
    }
}