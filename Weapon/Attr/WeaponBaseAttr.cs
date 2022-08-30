public class WeaponBaseAttr
{
    protected string mName;
    protected int mAtk;
    protected float mAtkRange;
    protected string mAssetName;

    public WeaponBaseAttr(string name, int atk, float atkRange, string assetName)
    {
        mName = name;
        mAtk = atk;
        mAtkRange = atkRange;
        mAssetName = assetName;
    }

    public string name => mName;
    public int atk => mAtk;
    public float atkRange => mAtkRange;
    public string assetName => mAssetName;

}