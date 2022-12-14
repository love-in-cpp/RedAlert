using System.Collections.Generic;
using UnityEngine;

public class SoldierFSMSystem
{
    private readonly List<ISoldierState> mStates = new();

    public ISoldierState currentState { get; private set; }

    public void AddState(params ISoldierState[] states)
    {
        foreach (var soldierState in states) AddState(soldierState);
    }

    public void AddState(ISoldierState state)
    {
        if (state is null)
        {
            Debug.LogError("SFSMS Error:要添加的状态为空");
            return;
        }

        if (mStates.Count == 0) // 判定重复之前，先判定集合是否是空集合，对第一个状态进行处理
        {
            mStates.Add(state);
            currentState = state;
            currentState.DoBeforeEntering();
            return;
        }

        foreach (var item in mStates)
            if (state.stateID == item.stateID) // 用对象相等去判断就肯定不对咯 - -||
                Debug.LogError("SFSMS Error: 已存在的状态[" + state.stateID + "]，无需添加！");
        mStates.Add(state);
    }

    public void DeleteState(SoldierStateID stateID)
    {
        if (stateID is SoldierStateID.NullState)
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

    public void PerformTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空：" + trans);
            return;
        }

        var nextStateID = currentState.GetOutputStateID(trans);
        if (nextStateID == SoldierStateID.NullState)
        {
            Debug.LogError("在转换条件[" + trans + "]下，没有对应的转换状态");
            return;
        }

        foreach (var item in mStates)
            if (nextStateID == item.stateID)
            {
                currentState.DoBeforeLeaving();
                currentState = item;
                currentState.DoBeforeEntering();
                return;
            }
    }
}