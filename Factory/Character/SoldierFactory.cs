﻿using System;
using UnityEngine;

public class SoldierFactory:ICharacterFactory
{
    public ICharacter CreatCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();
        
        // 创建角色游戏物体
        // 1. 加载 // 2. 实例化 todo
        
        // 添加武器 todo
        
        // 
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = "";
        string prefabName = "";
        
        var t = typeof(T);
        if (t == typeof(SoldierCaptain))
        {
            name = "上尉士兵";
            maxHP = 100;
            moveSpeed = 3f;
            iconSprite = "CaptainIcon";
            prefabName = "Soldier1";
            
        }
        else if (t == typeof(SoldierSergeant))
        {
            name = "中士士兵";
            maxHP = 90;
            moveSpeed = 2f;
            iconSprite = "SergeantIcon";
            prefabName = "Soldier3";
        }
        else if (t == typeof(SoldierRookie))
        {
            name = "下士士兵";
            maxHP = 50;
            moveSpeed = 1.5f;
            iconSprite = "RookieIcon";
            prefabName = "Soldier2";
        }
        else
        {
            Debug.LogError("类型" +t.Name+"不属于ISoldier，无法创建战士");
            return null;
        }

        ICharacterAttr attr =
            new SoilderAttr(new SoilderAttrStrategy(), name, maxHP, moveSpeed, iconSprite, prefabName);
        character.attr = attr;
        
        return null;
    }
}