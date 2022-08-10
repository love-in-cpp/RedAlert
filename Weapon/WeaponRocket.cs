using UnityEngine;

public class WeaponRocket : IWeapon
{
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.3f, targetPosition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RocketShot");
    }

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.4f;
    }

    public WeaponRocket(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject)
    {
    }
}