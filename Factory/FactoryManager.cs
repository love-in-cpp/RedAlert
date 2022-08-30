public static class FactoryManager
{
    private static IAssetFactory mAssetFactory = null;
    private static ICharacterFactory mSoldierFactory = null;
    private static ICharacterFactory mEnemyFactory = null;
    private static IWeaponFactory mWeaponFactory = null;
    private static IAttrFactory mAttrFactory = null;

    public static IAssetFactory assetFactory
    {
        get
        {
            if (mAssetFactory is null)
            {
                mAssetFactory = new ResourcesAssetFactory();
            }

            return mAssetFactory;
        }
    }
    public static ICharacterFactory soldierFactory
    {
        get
        {
            if (mSoldierFactory is null)
            {
                mSoldierFactory = new SoldierFactory();
            }

            return mSoldierFactory;
        }
    }
    public static ICharacterFactory enemyFactory => mEnemyFactory ?? (mEnemyFactory = new EnemyFactory());
    public static IWeaponFactory weaponFactory => mWeaponFactory ??= new WeaponFactory();
    public static IAttrFactory attrFactory => mAttrFactory ??= new AttrFactory();
}