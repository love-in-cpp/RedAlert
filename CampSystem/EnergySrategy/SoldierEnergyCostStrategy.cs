using System;

public class SoldierEnergyCostStrategy:IEnergyCostStragy
{
    public override int GetCampUpgradeCount(SoldierType st, int lv)
    {
        int energy = 0;
        switch (st)
        {
            case SoldierType.Rookie:
                energy = 60;
                break;
            case SoldierType.Sergeant:
                energy = 65;
                break;
            case SoldierType.Captain:
                energy = 70;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(st), st, null);
                break;
        }
        energy += (lv - 1) * 2;
        if (energy > 100)
        {
            energy = 100;
        }

        return energy;
    }

    public override int GetWeaponUpgradeCost(WeaponType wt)
    {
        int energy = 0;
        switch (wt)
        {
            case WeaponType.Gun:
                energy = 30;
                break;
            case WeaponType.Rifle:
                energy = 40;
                break;
            case WeaponType.Rocket:
                break;
            case WeaponType.MAX:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(wt), wt, null);
        }

        return energy;
    }

    public override int GetSoldierTrainCost(SoldierType st, int lv)
    {
        int energy = 0;
        switch (st)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 15;
                break;
            case SoldierType.Captain:
                energy = 20;
                break;
            case SoldierType.Captive:
                return 10;
            default:
                throw new ArgumentOutOfRangeException(nameof(st), st, null);
        }
        energy += (lv - 1) * 2;
        return energy;
    }
}