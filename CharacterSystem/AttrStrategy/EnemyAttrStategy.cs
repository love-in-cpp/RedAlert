using UnityEngine;

public class EnemyAttrStategy : IAttrStrategy
{
    public override int GetExtraHPValue(int level)
    {
        return 0;
    }

    public override int GetDmgDescValue(int level)
    {
        return 0;
    }

    public override int GetCritDmg(float critRate)
    {
        if (Random.Range(0, 1f) <= critRate) return (int)(10 * Random.Range(0.5f, 1f));

        return 0;
    }
}