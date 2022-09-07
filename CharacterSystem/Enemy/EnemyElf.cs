public class EnemyElf : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}