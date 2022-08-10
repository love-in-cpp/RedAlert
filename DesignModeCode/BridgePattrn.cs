using UnityEngine;

public class BridgePattrn : MonoBehaviour
{
    private void Start()
    {
        ICharacter character = new SoldierCaptain();
        // character.Weapon = new WeaponGun();
        // character.Attack(new Vector3(1,1,1));
    }

    private void Update()
    {
    }
}