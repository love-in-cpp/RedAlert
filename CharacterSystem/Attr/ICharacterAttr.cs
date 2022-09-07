public class ICharacterAttr // 数值字段的抽象 
{
    protected CharacterBaseAttr mBaseAttr;
    protected IAttrStrategy mAttrStrategy;
    protected int mCurrentHP;
    
    protected int mLv;
    protected int mDmgDescValue;

    public int currentHP => mCurrentHP;
    public IAttrStrategy strategy => mAttrStrategy;
    public CharacterBaseAttr baseAttr => mBaseAttr;
    public ICharacterAttr(IAttrStrategy strategy, int lv, CharacterBaseAttr baseAttr)
    {
        mBaseAttr = baseAttr;
        mLv = lv;
        mAttrStrategy = strategy;
        mDmgDescValue = mAttrStrategy.GetDmgDescValue(mLv);
        mCurrentHP = baseAttr.maxHP + mAttrStrategy.GetExtraHPValue(mLv);
    }

    public void TakeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5) damage = 5;
        mCurrentHP -= damage;
    }
    
    public int critValue
    {
        get { return mAttrStrategy.GetCritDmg(mBaseAttr.critRate); }
    }
    
}