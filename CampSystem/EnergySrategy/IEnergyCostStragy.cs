public abstract class IEnergyCostStragy
{
    public abstract int GetCampUpgradeCount(SoldierType st, int lv);
    public abstract int GetWeaponUpgradeCost(WeaponType wt);
    public abstract int GetSoldierTrainCost(SoldierType st, int lv);
}