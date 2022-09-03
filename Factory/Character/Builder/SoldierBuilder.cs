using System;
using UnityEngine;

public class SoldierBuilder:ICharacterBuilder
{
    public SoldierBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 sapawnPosition, int lv) : base(character, t, weaponType, sapawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mT);
        mPrefabName = baseAttr.prefabName;
        ICharacterAttr attr = new SoilderAttr(new SoilderAttrStrategy(), mLv, baseAttr);
        mCharacter.attr = attr;
    }

    public override void AddGameObject()
    {
        // 创建角色游戏物体
        // 1. 加载 // 2. 实例化 
        GameObject characterGO = FactoryManager.assetFactory.LoadSoldier(mPrefabName);
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