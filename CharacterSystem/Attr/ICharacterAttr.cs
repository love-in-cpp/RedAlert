public class ICharacterAttr // 数值字段的抽象 
{
    protected IAttrStrategy mAttrStrategy;
    protected float mCritRate; // 暴击率 数值为 0-1的值
    protected int mCurrentHP;
    protected string mIconSprite; // string类型是因为只要接收精灵的名称

    protected int mLv;
    protected int mMaxHP;
    protected float mMoveSpeed;
    protected string mName;
    protected int mDmgDescValue;

    public int currentHP => mCurrentHP;
    public ICharacterAttr(IAttrStrategy strategy)
    {
        mAttrStrategy = strategy;
        mDmgDescValue = mAttrStrategy.GetDmgDescValue(mLv);
        mCurrentHP = mMaxHP + mAttrStrategy.GetExtraHPValue(mLv);
    }

    public void TakeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5) damage = 5;
        mCurrentHP -= damage;
    }
    
    public int critValue
    {
        get { return mAttrStrategy.GetCritDmg(mCritRate); }
    }
    
}