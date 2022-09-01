using UnityEngine;

public class SoldierCamp:ICamp
{
    private int mLv = 1;
    private const int MAX_LV = 4;
    private WeaponType mWeaponType = WeaponType.Gun; // 利用枚举类型的自增完成升级

    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position) 
        : base(gameObject, name, icon, soldierType, position)
    {
    }
    
}