using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected Animation mAnim;
    protected ICharacterAttr mAttr;
    protected AudioSource mAudio;
    protected GameObject mGameObject; // 当前关联的游戏对象
    protected NavMeshAgent mNavAgent;

    protected IWeapon mWeapon;

    public IWeapon Weapon
    {
        get => mWeapon;
        set => mWeapon = value;
    }

    public Vector3 Position
    {
        get
        {
            if (mGameObject is null)
            {
                Debug.LogError("当前ICharacter实例绑定的GameObject为空");
                return Vector3.zero;
            }

            return mGameObject.transform.position;
        }
    }

    public float AtkRange => mWeapon.AtkRange;
    public abstract void UpdateFSMAI(List<ICharacter> targets);
    public void Update()
    {
        mWeapon.Update();
    }
    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.Position);
        mGameObject.transform.LookAt(target.Position);
        PlayAnim("attack");
        target.UnderAttack(mWeapon.Atk + mAttr.critValue);
    }

    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDamage(damage);
    }

    public void PlayAnim(string animName)
    {
        mAnim.CrossFade(animName);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        mNavAgent.SetDestination(targetPosition);
        PlayAnim("move");
    }
}