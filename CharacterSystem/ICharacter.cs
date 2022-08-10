﻿using System.Collections.Generic;
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
    public ICharacterAttr attr
    {
        set => mAttr = value;
    }

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
        
        // 被攻击的效果 （没有被攻击的音效）、视效
        
        // 死亡效果 音效、视效 （只有战士有）
        
    }

    public void Killed()
    {
         // Todo
    }
    protected void DoPlayEffect(string effectName)
    {
        // 加载特效 Todo
        GameObject effectGO; // 特效的游戏物体
        // 控制销毁 协程 Todo
        
    }
    protected void DoPlaySound(string soundName)
    {
        AudioClip clip = null; // todo
        mAudio.clip = clip;
        mAudio.Play();
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