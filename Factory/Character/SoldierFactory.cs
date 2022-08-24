using System;
using UnityEngine;

public class SoldierFactory:ICharacterFactory
{
    public ICharacter CreatCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();
        
        ICharacterBuilder builder = new SoldierBuilder(character, typeof(T), weaponType, spawnPosition, lv);
        return CharacterBuilderDirector.Construct(builder);

    }
}