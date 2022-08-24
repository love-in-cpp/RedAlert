using System;
using UnityEngine;

public abstract class ICharacterBuilder
{
    protected Type mT;
    protected WeaponType mWeaponType;
    protected Vector3 mSapawnPosition;
    protected int mLv;

    public ICharacterBuilder(Type t, WeaponType weaponType, Vector3 sapawnPosition, int lv)
    {
        mT = t;
        mWeaponType = weaponType;
        mSapawnPosition = sapawnPosition;
        mLv = lv;
    }
    
    
    public abstract void AddCharacterAttr();
    public abstract void AddGameObject();
    public abstract void AddWeapon();
}