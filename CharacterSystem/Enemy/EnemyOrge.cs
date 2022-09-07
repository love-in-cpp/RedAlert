public class EnemyOrge : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}