public class SoilderAttr : ICharacterAttr
{
    public SoilderAttr(IAttrStrategy strategy, string name, int maxHP, float moveSpeed, string iconSprite, string prefabName) : base(strategy, name, maxHP, moveSpeed, iconSprite, prefabName)
    {
    }
}