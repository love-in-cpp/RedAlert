using System.Collections.Generic;
using UnityEngine;

internal class EnemyChaseState : IEnemyState
{
    private Vector3 mTargetPosition;
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter character) : base(EnemyStateID.Chase,fsm,character)
    {
    }

    public override void Reason(List<ICharacter> targets)
    {
        // 这里应该是检测距离 Todo
        if (targets is not null && targets.Count > 0) mFSM.PerformTransition(EnemyTransition.SeeSoldier);
    }

    public override void DoBeforeEntering()
    {
        mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets is not null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].Position);
        }
        else
        {
            mCharacter.MoveTo(mTargetPosition);    
        }
        
        // 前往基地
    }
}