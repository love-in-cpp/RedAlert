using System;
using UnityEngine;

public class EnemyFactory:ICharacterFactory
{
    public ICharacter CreatCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = "";
        string prefabName = "";

        Type t = character.GetType();
        if (t == typeof(EnemyElf))
        {
            name = "小精灵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            prefabName = "Enemy1";
        }
        else if (t == typeof(EnemyOrge))
        {
            name = "怪物";
            maxHP = 120;
            moveSpeed = 4;
            iconSprite = "OgreIcon";
            prefabName = "Enemy2";
        }
        else if (t == typeof(EnemyOrge))
        {
            name = "巨魔";
            maxHP = 200;
            moveSpeed = 1;
            iconSprite = "TrollIcon";
            prefabName = "Enemy3";
        }
        else
        {
            Debug.LogError("类型" +t.Name+"不属于ISoldier，无法创建敌人");
            return null;
        }
        ICharacterAttr attr =
            new EnemyAttr(new EnemyAttrStategy(), lv, name, maxHP, moveSpeed, iconSprite, prefabName);
        character.attr = attr;

        GameObject characterGO = FactoryManager.assetFactory.LoadEnemy(prefabName);
        characterGO.transform.position = spawnPosition;// 生成的初始位置
        character.gameObject = characterGO;

        character.weapon = FactoryManager.weaponFactory.CreatWeapon(weaponType);

        return character;
    }
}