// using System.Collections.Generic;
// using UnityEngine;
//
// internal class EnemyChaseState : IEnemyState
// {
//     private Vector3 mTargetPosition;
//     public EnemyChaseState(EnemyFSMSystem fsm, ICharacter character) : base(EnemyStateID.Chase,fsm,character)
//     {
//     }
//
//     public override void Reason(List<ICharacter> targets)
//     {
//         // 这里应该是检测距离 Todo
//         if (targets is not null && targets.Count > 0) mFSM.PerformTransition(EnemyTransition.SeeSoldier);
//     }
//
//     public override void DoBeforeEntering()
//     {
//         mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
//     }
//
//     public override void Act(List<ICharacter> targets)
//     {
//         if (targets is not null && targets.Count > 0)
//         {
//             mCharacter.MoveTo(targets[0].Position);
//         }
//         else
//         {
//             mCharacter.MoveTo(mTargetPosition);    
//         }
//         
//         // 前往基地
//     }
// }
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyChaseState:IEnemyState
{
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter c):base(fsm,c)
    {
        mStateID = EnemyStateID.Chase;
    }
    private Vector3 mTargetPosition;
    public override void DoBeforeEntering()
    {
        mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if (distance <= mCharacter.AtkRange)
            {
                mFSM.PerformTransition(EnemyTransition.CanAttack);
            }
        }
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].Position);
        } else
        {
            mCharacter.MoveTo(mTargetPosition);
        }
    }
}
