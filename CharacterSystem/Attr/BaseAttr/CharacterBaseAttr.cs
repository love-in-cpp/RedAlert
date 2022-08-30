public class CharacterBaseAttr
{
    protected int mMaxHP;
    protected string mName;
    protected float mMoveSpeed;
    protected string mIconSprite; // string类型是因为只要接收精灵的名称
    protected string mPrefabName; // 用于实例化的预制体的名称
    protected float mCritRate; // 暴击率 数值为 0-1的值

    public CharacterBaseAttr(string mName, int mMaxHP, float mMoveSpeed, string mIconSprite, string mPrefabName, float mCritRate)
    {
        this.mMaxHP = mMaxHP;
        this.mName = mName;
        this.mMoveSpeed = mMoveSpeed;
        this.mIconSprite = mIconSprite;
        this.mPrefabName = mPrefabName;
        this.mCritRate = mCritRate;
    }

    public string name => mName;
    public int maxHP => mMaxHP;
    public float moveSpeed => mMoveSpeed;
    public string iconSprite => mIconSprite;
    public float critRate => mCritRate;
    public string prefabName => mPrefabName;

}