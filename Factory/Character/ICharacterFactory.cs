using UnityEngine;

public interface ICharacterFactory
{
    ICharacter CreatCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1)where T : ICharacter,new();
}