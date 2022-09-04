public class CharacterBuilderDirector
{
    public static ICharacter Construct(ICharacterBuilder builder)
    {
        builder.AddCharacterAttr();
        builder.AddGameObject();
        builder.AddWeapon();
        builder.AddInCharacterSystem();
        return builder.GetResult();
    }
    
        
}