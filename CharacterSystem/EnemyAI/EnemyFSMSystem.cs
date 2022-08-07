using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFSMSystem
{
    private IEnemyState mCurrentState;

    public IEnemyState currentState
    {
        get => mCurrentState;
    }

    // private IEnemyState mNextStateID;
    private readonly List<IEnemyState> mStates = new();

    public void AddState(params IEnemyState[] state)
    {
        foreach (var enemyState in state)
        {
            AddState(enemyState);
        }
    }
    
    public void AddState(IEnemyState state)
    {
        if (state is null)
        {
            Debug.LogError("SFSMS Error:要添加的状态为空");
            return;
        }

        if (mStates.Count == 0) // 判定重复之前，先判定集合是否是空集合，对第一个状态进行处理
        {
            mStates.Add(state);
            mCurrentState = state;
            mCurrentState.DoBeforeEntering();
            return;
        }

        foreach (var item in mStates)
            if (state.stateID == item.stateID) // 用对象相等去判断就肯定不对咯 - -||
                Debug.LogError("SFSMS Error: 已存在的状态[" + state.stateID + "]，无需添加！");
        mStates.Add(state);
    }
    
    public void DeleteState(EnemyStateID stateID)
    {
        if (stateID is EnemyStateID.NullState)
        {
            Debug.LogError("SFSMS Error:空状态不可删除");
            return;
        }

        foreach (var item in mStates)
            if (item.stateID == stateID)
            {
                mStates.Remove(item);
                return;
            }

        Debug.LogError("SFSMS　Error: ID为[" + stateID + "]的State 不存在");
    }

    public void PerformTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空：" + trans);
            return;
        }
    
        var nextStateID = mCurrentState.GetOutputStateID(trans); // switch point 
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.LogError("在转换条件[" + trans + "]下，没有对应的转换状态");
            return;
        }
        foreach (var item in mStates)
            if (item.stateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = item;
                mCurrentState.DoBeforeEntering();
            }
    }
}