using System;
using UnityEngine;

public class WeaponFactory:IWeaponFactory
{
    public IWeapon CreatWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        string assetName = "";
        IAssetFactory factory = new ResourcesAssetFactory();
        GameObject weaponGO;
        switch (weaponType)
        {
            case WeaponType.Gun:
                assetName = "WeaponGun";
                weaponGO = factory.LoadWeapon(assetName);
                weapon = new WeaponGun(20, 5, weaponGO);
                break;
            case WeaponType.Rifle:
                assetName = "WeaponRifle";
                weaponGO = factory.LoadWeapon(assetName);
                weapon = new WeaponGun(30, 7, weaponGO);
                break;
            case WeaponType.Rocket:
                assetName = "WeaponRocket";
                weaponGO = factory.LoadWeapon(assetName);
                weapon = new WeaponGun(40, 8, weaponGO);
                break;
        }

        return weapon;




    }
}