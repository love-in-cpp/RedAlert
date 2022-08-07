using System.Collections.Generic;
using UnityEngine;

public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mStateID = SoldierStateID.Chase;
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets is null || targets.Count == 0)
        {
            mFSM.PerformTransition(SoldierTransition.LoseEnemy);
            return;
        }

        var distance = Vector3.Distance(targets[0].Position, mCharacter.Position);
        if (distance <= mCharacter.AtkRange) mFSM.PerformTransition(SoldierTransition.CanAttack);
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets is not null && targets.Count > 0) mCharacter.MoveTo(targets[0].Position);
    }
}