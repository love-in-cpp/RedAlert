using System;using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Elf,
    Ogre,
    Troll,
}
public abstract class IEnemy : ICharacter
{
    protected EnemyFSMSystem mFSMSystem;

    public IEnemy()
    {
        MakeFSM();
    }

    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        mFSMSystem.currentState.Reason(targets);
        mFSMSystem.currentState.Act(targets);
    }

    private void MakeFSM()
    {
        mFSMSystem = new EnemyFSMSystem();

        EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem, this);
        chaseState.AddTransition(EnemyTransition.SeeSoldier,EnemyStateID.Attack);

        EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
        attackState.AddTransition(EnemyTransition.NoSoldier,EnemyStateID.Chase);
        
        mFSMSystem.AddState(chaseState,attackState);
    }

    public override void UnderAttack(int damage)
    {
        base.UnderAttack(damage);
        PlayEffect();
    }

    protected abstract void PlayEffect();

    
}