using UnityEngine;

public class WeaponRifle : IWeapon
{
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.1f, targetPosition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RifleShot");
    }

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.3f;
    }
}