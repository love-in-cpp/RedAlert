public class SoilderAttrStrategy : IAttrStrategy
{
    public override int GetExtraHPValue(int level)
    {
        return (level - 1) * 10;
    }

    public override int GetDmgDescValue(int level)
    {
        return (level - 1) * 5;
    }

    public override int GetCritDmg(float critRate)
    {
        return 0;
    }
}