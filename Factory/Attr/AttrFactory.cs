using System;
using System.Collections.Generic;
using UnityEngine;


public class AttrFactory:IAttrFactory
{
    private Dictionary<Type, CharacterBaseAttr> mCharaterBaseAttrDict;
    private Dictionary<WeaponType, WeaponBaseAttr> mWeaponBaseAttrDict;

    public AttrFactory()
    {
        InitCharacterBaseAttr();
        
    }

    private void InitCharacterBaseAttr()
    {
        mCharaterBaseAttrDict = new Dictionary<Type, CharacterBaseAttr>();
        mCharaterBaseAttrDict.Add(typeof(SoldierRookie), new CharacterBaseAttr("下士士兵",50,2.5f, "RookieIcon", "Soldier2", 0));
        mCharaterBaseAttrDict.Add(typeof(SoldierSergeant), new CharacterBaseAttr("中士士兵", 90, 2f,"SergeanIcon","Soldier3", 0));
        mCharaterBaseAttrDict.Add(typeof(SoldierCaptain), new CharacterBaseAttr("上尉士兵", 100, 3f,"CaptainIcon","Soldier1", 0));
        mCharaterBaseAttrDict.Add(typeof(EnemyElf), new CharacterBaseAttr("小精灵", 100, 3, "ElfIcon", "Enemy1", 0.2f));
        mCharaterBaseAttrDict.Add(typeof(EnemyOrge), new CharacterBaseAttr("怪物", 120, 2, "OgreIcon", "Enemy2", 0.3f));
        mCharaterBaseAttrDict.Add(typeof(EnemyTroll), new CharacterBaseAttr("巨魔", 200, 1, "TrollIcon", "Enemy3", 0.4f));
    }

    private void InitWeaponBaseAttr()
    {
        mWeaponBaseAttrDict = new Dictionary<WeaponType, WeaponBaseAttr>();
        mWeaponBaseAttrDict.Add(WeaponType.Gun, new WeaponBaseAttr("短枪", 20, 5, "WeaponGun"));
        mWeaponBaseAttrDict.Add(WeaponType.Rifle, new WeaponBaseAttr("长枪", 30, 7, "WeaponRifle"));
        mWeaponBaseAttrDict.Add(WeaponType.Rocket, new WeaponBaseAttr("火箭", 40, 8, "WeaponRocket"));
    }
    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        if (mCharaterBaseAttrDict.ContainsKey(t) == false)
        {
            Debug.LogError("无法根据类型"+ t + "得到角色基础属性(GetCharacterBaseAttr)");
            return null;
        }

        return mCharaterBaseAttrDict[t];
    }

    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType t)
    {
        if (mWeaponBaseAttrDict.ContainsKey(t) == false)
        {
            Debug.LogError("无法根据类型"+ t + "得到武器基础属性(GetWeaponBaseAttr)");
            return null;
        }

        return mWeaponBaseAttrDict[t];
    }
}