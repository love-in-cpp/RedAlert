using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IEnemyState
{
    private float mAttackTime = 1f;
    private float mAttackTimer = 0;
    public EnemyAttackState(EnemyFSMSystem fsm, ICharacter character) : base(EnemyStateID.Attack,fsm,character)
    {
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets is null || targets.Count == 0)
        {
            mFSM.PerformTransition(EnemyTransition.NoSoldier);
        }
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets is not null && targets.Count > 0)
        {
            mAttackTimer += Time.deltaTime;
            if (mAttackTimer >= mAttackTime)
            {
                mCharacter.Attack(targets[0]);
                mAttackTimer = 0;
            }

        }
    }
}