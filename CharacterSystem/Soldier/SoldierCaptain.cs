public class SoldierCaptain : ISoldier
{
    protected override void PlaySound()
    {
        DoPlayEffect("CaptainDeadEffect");
    }

    protected override void PlayEffect()
    {
        DoPlaySound("CaptainDeath");
    }
}