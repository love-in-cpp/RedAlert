public class SoldierSergeant : ISoldier
{
    protected override void PlaySound()
    {
        DoPlayEffect("SergeantDeadEffect");
    }

    protected override void PlayEffect()
    {
        DoPlaySound("SergeantDeath");
    }
}