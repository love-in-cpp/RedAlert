// using System.Collections.Generic;
// using UnityEngine;
//
// public class EnemyAttackState : IEnemyState
// {
//     private float mAttackTime = 1f;
//     private float mAttackTimer = 0;
//     public EnemyAttackState(EnemyFSMSystem fsm, ICharacter character) : base(EnemyStateID.Attack,fsm,character)
//     {
//     }
//
//     public override void Reason(List<ICharacter> targets)
//     {
//         if (targets is null || targets.Count == 0)
//         {
//             mFSM.PerformTransition(EnemyTransition.NoSoldier);
//         }
//         else
//         {
//             float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
//             if (distance > mCharacter.AtkRange)
//             {
//                 mFSM.PerformTransition(EnemyTransition.NoSoldier);
//             }
//         }
//     }
//
//     public override void Act(List<ICharacter> targets)
//     {
//         if (targets is not null && targets.Count > 0)
//         {
//             mAttackTimer += Time.deltaTime;
//             if (mAttackTimer >= mAttackTime)
//             {
//                 mCharacter.Attack(targets[0]);
//                 mAttackTimer = 0;
//             }
//
//         }
//     }
// }

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyAttackState:IEnemyState
{
    public EnemyAttackState(EnemyFSMSystem fsm, ICharacter c):base(fsm,c)
    {
        mStateID = EnemyStateID.Attack;
        mAttackTimer = mAttackTime;
    }
    private float mAttackTime = 1;
    private float mAttackTimer = 1;

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFSM.PerformTransition(EnemyTransition.LostSoldier);
        } else
        {
            float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if (distance > mCharacter.AtkRange)
            {
                mFSM.PerformTransition(EnemyTransition.LostSoldier);
            }
        }
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0) return;
        mAttackTimer += Time.deltaTime;
        if (mAttackTimer >= mAttackTime)
        {
            mCharacter.Attack(targets[0]);
            mAttackTimer = 0;
        }
    }
}
