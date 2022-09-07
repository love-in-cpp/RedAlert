public class SoldierCaptive:ISoldier
{
    private IEnemy mEnemy;

    public SoldierCaptive(IEnemy enemy)
    {
        mEnemy = enemy;
        // todo
        ICharacterAttr attr = new SoilderAttr(mEnemy.attr.strategy, 1, mEnemy.attr.baseAttr);
        this.attr = attr; // 适配Enemy属性给Soldier

        this.gameObject = mEnemy.gameObject;
        this.weapon = mEnemy.weapon;
    }
    protected override void PlaySound()
    {
    }

    protected override void PlayEffect()
    {
        mEnemy.PlayEffect();
    }
}