public class EnemyTroll : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("TrollHitEffect");
    }
}