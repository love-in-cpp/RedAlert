using System;
using UnityEngine;

public class WeaponFactory:IWeaponFactory
{
    public IWeapon CreatWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        IAssetFactory factory = FactoryManager.assetFactory;
        WeaponBaseAttr baseAttr = FactoryManager.attrFactory.GetWeaponBaseAttr(weaponType);
        GameObject weaponGO = FactoryManager.assetFactory.LoadWeapon(baseAttr.assetName);
        
        weapon = new WeaponGun(baseAttr, weaponGO);

        return weapon;




    }
}