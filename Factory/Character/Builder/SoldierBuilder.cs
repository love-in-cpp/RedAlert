using System;
using UnityEngine;

public class SoldierBuilder:ICharacterBuilder
{
    public SoldierBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 sapawnPosition, int lv) : base(character, t, weaponType, sapawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = "";


        if (mT == typeof(SoldierCaptain))
        {
            name = "上尉士兵";
            maxHP = 100;
            moveSpeed = 3f;
            iconSprite = "CaptainIcon";
            mPrefabName = "Soldier1";
            
        }
        else if (mT == typeof(SoldierSergeant))
        {
            name = "中士士兵";
            maxHP = 90;
            moveSpeed = 2f;
            iconSprite = "SergeantIcon";
            mPrefabName = "Soldier3";
        }
        else if (mT == typeof(SoldierRookie))
        {
            name = "下士士兵";
            maxHP = 50;
            moveSpeed = 1.5f;
            iconSprite = "RookieIcon";
            mPrefabName = "Soldier2";
        }
        else
        {
            Debug.LogError("类型" +mT.Name+"不属于ISoldier，无法创建战士");
        }

        ICharacterAttr attr =
            new SoilderAttr(new SoilderAttrStrategy(), mLv, name, maxHP, moveSpeed, iconSprite, mPrefabName);
        mCharacter.attr = attr;
    }

    public override void AddGameObject()
    {
        // 创建角色游戏物体
        // 1. 加载 // 2. 实例化 
        GameObject characterGO = FactoryManager.assetFactory.LoadEnemy(mPrefabName);
        characterGO.transform.position = mSapawnPosition;
        mCharacter.gameObject = characterGO;
    }

    public override void AddWeapon()
    {
        // 添加武器 
        IWeapon weapon = FactoryManager.weaponFactory.CreatWeapon(mWeaponType);
        mCharacter.weapon = weapon;
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}