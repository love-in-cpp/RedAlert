public abstract class IAttrStrategy
{
    public abstract int GetExtraHPValue(int level);
    public abstract int GetDmgDescValue(int level);
    public abstract int GetCritDmg(float critRate);
}