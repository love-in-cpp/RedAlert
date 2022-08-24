using System;
using UnityEngine;

public class EnemyBuilder:ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 sapawnPosition, int lv) : base(
        character, t, weaponType, sapawnPosition, lv)
    {
        
    }

    public override void AddCharacterAttr()
    {
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = "";
        string mPrefabName = "";
        
        if (mT == typeof(EnemyElf))
        {
            name = "小精灵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            mPrefabName = "Enemy1";
        }
        else if (mT == typeof(EnemyOrge))
        {
            name = "怪物";
            maxHP = 120;
            moveSpeed = 4;
            iconSprite = "OgreIcon";
            mPrefabName = "Enemy2";
        }
        else if (mT == typeof(EnemyOrge))
        {
            name = "巨魔";
            maxHP = 200;
            moveSpeed = 1;
            iconSprite = "TrollIcon";
            mPrefabName = "Enemy3";
        }
        else
        {
            Debug.LogError("类型" + mT.Name + "不属于ISoldier，无法创建敌人");
        }
        ICharacterAttr attr =
            new EnemyAttr(new EnemyAttrStategy(), mLv, name, maxHP, moveSpeed, iconSprite, mPrefabName);
        mCharacter.attr = attr;
    }

    public override void AddGameObject()
    {
        GameObject characterGO = FactoryManager.assetFactory.LoadEnemy(mPrefabName);
        characterGO.transform.position = mSapawnPosition;// 生成的初始位置
        mCharacter.gameObject = characterGO;
    }

    public override void AddWeapon()
    {
        mCharacter.weapon = FactoryManager.weaponFactory.CreatWeapon(mWeaponType);
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}