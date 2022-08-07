using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackState : ISoldierState
{
    private readonly float mAttackTime = 1;
    private float mAttackTimer = 0;

    public SoldierAttackState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mStateID = SoldierStateID.Attack;
        mAttackTimer = mAttackTime;
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets is null || targets.Count == 0)
        {
            mFSM.PerformTransition(SoldierTransition.LoseEnemy);
            return;
        }

        var distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
        if (distance > mCharacter.AtkRange) mFSM.PerformTransition(SoldierTransition.SeeEnemy);
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets is null || targets.Count == 0) return;

        mAttackTimer += Time.deltaTime;
        if (mAttackTimer >= mAttackTime)
        {
            mCharacter.Attack(targets[0]);
            mAttackTimer = 0;
        }
    }
}