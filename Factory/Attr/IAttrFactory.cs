public interface IAttrFactory
{
    CharacterBaseAttr GetCharacterBaseAttr(System.Type t);
    WeaponBaseAttr GetWeaponBaseAttr(WeaponType t);

}