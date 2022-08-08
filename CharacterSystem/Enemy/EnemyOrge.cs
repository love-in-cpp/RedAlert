public class EnemyOrge : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}