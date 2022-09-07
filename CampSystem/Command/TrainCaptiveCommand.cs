using System;
using UnityEngine;

public class TrainCaptiveCommand:ITrainCommand
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private Vector3 mPosition;
    private int mLv;

    public TrainCaptiveCommand(EnemyType et, WeaponType wt, Vector3 pos, int lv)
    {
        mEnemyType = et;
        mWeaponType = wt;
        mPosition = pos;
        mLv = lv;
    }
    
    public override void Execute()
    {
        IEnemy enemy = null;
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.enemyFactory.CreatCharacter<EnemyElf>(mWeaponType, mPosition) as IEnemy;
                break;
            case EnemyType.Ogre:
                enemy = FactoryManager.enemyFactory.CreatCharacter<EnemyOrge>(mWeaponType, mPosition) as IEnemy;
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.enemyFactory.CreatCharacter<EnemyTroll>(mWeaponType, mPosition) as IEnemy;
                break;
            default:
                Debug.Log("无法创建俘兵："+ mEnemyType);
                return;
        }
        GameFacade.Instance.RemoveEnemy(enemy);
        SoldierCaptive captive = new SoldierCaptive(enemy);
        GameFacade.Instance.AddSoldier(captive);
    }
}