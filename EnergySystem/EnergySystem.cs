using System;
using UnityEngine;

public class EnergySystem : IGameSystem
{
    private const float MAX_Energy = 100;
    private float mNowEnergy = MAX_Energy;

    private float mRecoverSpeed = 3;
    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        base.Update();
        if (mNowEnergy >= MAX_Energy)
        {
            return; 
        }

        mNowEnergy += mRecoverSpeed * Time.deltaTime; // todo 想不起来为什么要乘以 deltatime了
        // if (mNowEnergy > MAX_Energy)
        // {
        //     mNowEnergy = MAX_Energy;
        // }
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_Energy);
    }

    public override void Release()
    {
    }

    public bool TakeEnergy(int value)
    {
        if (mNowEnergy >= value)
        {
            mNowEnergy -= value;
            return true;
        }
        else
        {
            return false;
        }
    }
}