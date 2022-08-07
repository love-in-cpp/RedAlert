using System.Collections.Generic;
using UnityEngine;

public enum SoldierTransition
{
    NullTransition,
    SeeEnemy,
    LoseEnemy,
    CanAttack
}

public enum SoldierStateID
{
    NullState,
    Idle,
    Chase,
    Attack
}

public abstract class ISoldierState
{
    protected ICharacter mCharacter;
    protected SoldierFSMSystem mFSM;
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new();
    protected SoldierStateID mStateID;

    public ISoldierState(SoldierFSMSystem fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }

    public SoldierStateID stateID => mStateID;

    public void AddTransition(SoldierTransition trans, SoldierStateID id)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("SoldierState Error: trans不能为空");
            return;
        }

        if (id == SoldierStateID.NullState)
        {
            Debug.LogError("SoilderState Error: id状态不能为空！");
            return;
        }

        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error :" + trans + "已经添加上了");
            return;
        }

        mMap.Add(trans, id);
    }

    public void DeleteTransition(SoldierTransition trans)
    {
        if (mMap.ContainsKey(trans) is false)
        {
            Debug.LogError("SoldierTransition Error:删除转换条件失败，转换条件:[" + trans + "]不存在");
            return;
        }

        mMap.Remove(trans);
    }

    public SoldierStateID GetOutputStateID(SoldierTransition trans)
    {
        if (mMap.ContainsKey(trans) is false)
            // Debug.LogError("SoldierTransition Error: 获取状态失败，转换条件:["+ trans +"]不存在");
            return SoldierStateID.NullState;
        return mMap[trans];
    }

    public virtual void DoBeforeEntering()
    {
    }

    public virtual void DoBeforeLeaving()
    {
    }

    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}