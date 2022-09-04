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
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mT);
        mPrefabName = baseAttr.prefabName;
        ICharacterAttr attr = 
            new EnemyAttr(new EnemyAttrStategy(), mLv, baseAttr);
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

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddEnemy(mCharacter as IEnemy);
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}