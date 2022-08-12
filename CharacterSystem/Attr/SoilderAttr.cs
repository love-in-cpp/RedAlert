public class SoilderAttr : ICharacterAttr
{
    public SoilderAttr(IAttrStrategy strategy,int lv,  string name, int maxHP, float moveSpeed, string iconSprite, string prefabName) : base(strategy, lv, name, maxHP, moveSpeed, iconSprite, prefabName)
    {
    }
}