using System;
using UnityEngine;

public class EnemyFactory:ICharacterFactory
{
    public ICharacter CreatCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();
        
        ICharacterBuilder builder = new EnemyBuilder(character, typeof(T), weaponType, spawnPosition, lv);
        return CharacterBuilderDirector.Construct(builder);
    }
}