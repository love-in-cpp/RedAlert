public class EnemyElf : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}