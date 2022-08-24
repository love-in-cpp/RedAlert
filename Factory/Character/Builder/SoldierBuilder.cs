using System;
using UnityEngine;

public class SoldierBuilder:ICharacterBuilder
{
    public SoldierBuilder(Type t, WeaponType weaponType, Vector3 sapawnPosition, int lv) : base(t, weaponType, sapawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {
    }

    public override void AddGameObject()
    {
    }

    public override void AddWeapon()
    {
    }
}