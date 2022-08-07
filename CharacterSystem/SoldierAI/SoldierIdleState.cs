using System.Collections.Generic;

public class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mStateID = SoldierStateID.Idle;
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets is not null && targets.Count > 0) // 有目标就去追
            mFSM.PerformTransition(SoldierTransition.SeeEnemy);
        // foreach (var key in mMap.Keys)
        // {
        //     if (mMap[key]==SoldierStateID.Chase)
        //     {
        //         mFSM.PerformTransition(key); 
        //     }
        // }
    }

    public override void Act(List<ICharacter> targets)
    {
        mCharacter.PlayAnim("stand");
    }
}