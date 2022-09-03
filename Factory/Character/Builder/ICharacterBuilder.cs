using System;
using UnityEngine;

public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter;
    protected Type mT;
    protected WeaponType mWeaponType;
    protected Vector3 mSapawnPosition;
    protected int mLv;
    
    protected string mPrefabName = "";

    public ICharacterBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 sapawnPosition, int lv)
    {
        mCharacter = character;
        mT = t;
        mWeaponType = weaponType;
        mSapawnPosition = sapawnPosition;
        mLv = lv;
    }
    
    
    public abstract void AddCharacterAttr();
    public abstract void AddGameObject();
    public abstract void AddWeapon();
    public abstract void AddInCharacterSystem();

    public abstract ICharacter GetResult();
}