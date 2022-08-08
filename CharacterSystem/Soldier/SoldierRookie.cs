public class SoldierRookie : ISoldier
{
    protected override void PlaySound()
    {
        DoPlayEffect("RookieDeadEffect");
    }

    protected override void PlayEffect()
    {
        DoPlaySound("RookieDeath");
    }
}