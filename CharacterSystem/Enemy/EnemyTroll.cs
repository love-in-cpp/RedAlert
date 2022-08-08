public class EnemyTroll : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffect("TrollHitEffect");
    }
}