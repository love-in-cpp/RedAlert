using System;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTransition
{
    NullTransition,
    SeeSoldier,
    NoSoldier,
}

public enum EnemyStateID
{
    NullState,
    Chase,
    Attack,
}

public abstract class IEnemyState
{
    protected Dictionary<EnemyTransition, EnemyStateID> mDic = new();
    protected EnemyStateID mStateID;
    protected ICharacter mCharacter;
    protected EnemyFSMSystem mFSM;
    public EnemyStateID stateID => mStateID;
    public IEnemyState(EnemyStateID mStateID,EnemyFSMSystem fsm, ICharacter character)
    {
        this.mStateID = mStateID;
        mFSM = fsm;
        mCharacter = character;
        
    }
    

    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("EnemyState Error: trans不能为空");
            return;
        }

        if (id == EnemyStateID.NullState)
        {
            Debug.LogError("SoldierState Error: id状态不能为空！");
            return;
        }

        if (mDic.ContainsKey(trans))
        {
            Debug.LogError("EnemyState Error :" + trans + "已经添加上了");
            return;
        }
        mDic.Add(trans, id);
    }

    public void DeleteTransition(EnemyTransition trans)
    {
        if (mDic.ContainsKey(trans) is false)
        {
            Debug.LogError("EnemyTransition Error:删除转换条件失败，转换条件:[" + trans + "]不存在");
            return;
        }

        mDic.Remove(trans);
    }

    public EnemyStateID GetOutputStateID(EnemyTransition trans)
    {
        if (mDic.ContainsKey(trans) is false)
            // Debug.LogError("EnemyTransition Error: 获取状态失败，转换条件:["+ trans +"]不存在");
            return EnemyStateID.NullState;
        return mDic[trans];
    }
    public virtual void Reason(List<ICharacter> targets)
    {
    }

    public virtual void Act(List<ICharacter> targets)
    {
    }
    
    public virtual void DoBeforeLeaving()
    {
        
    }

    public virtual void DoBeforeEntering()
    {
        
    }
}