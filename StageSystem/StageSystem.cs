using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StageSystem : IGameSystem
{
    private int mLv = 1;
    private List<Vector3> mPosList;
    private IStageHandler mRootHandler;
    private Vector3 mTargetPosition;
    private int mCountOfEnemyKilled = 0;
    public override void Init()
    {
        base.Init();
        InitPosition();
        InitStageChain();
        mGameFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverStageSystem(this));
    }

    private void InitPosition()
    {
        mPosList = new List<Vector3>();
        int i = 1;
        while (true)
        {
            GameObject go = GameObject.Find("Position"+i);
            if (go is not null)
            {
                mPosList.Add(go.transform.position);
                go.SetActive(false);
                i++;
            }
            else
            {
                break;
            }
        }
        GameObject targetPos = GameObject.Find("TargetPosition");
        mTargetPosition = targetPos.transform.position;

    }

    private Vector3 GetRandomPosition()
    {
        return mPosList[Random.Range(0, mPosList.Count)];
    }
    

    public override void Update()
    {
        base.Update();
        mRootHandler.Handle(mLv);
    }

    public override void Release()
    {
    }

    private void InitStageChain()
    {
        int lv = 1;
        NormalStageHandler handler1 =
            new NormalStageHandler(this, lv++, 3, EnemyType.Elf, WeaponType.Gun, 3, GetRandomPosition());
        NormalStageHandler handler2 =
            new NormalStageHandler(this, lv++, 6, EnemyType.Elf, WeaponType.Rifle, 3, GetRandomPosition());
        NormalStageHandler handler3 =
            new NormalStageHandler(this, lv++, 9, EnemyType.Elf, WeaponType.Rocket, 3, GetRandomPosition());
        NormalStageHandler handler4 =
            new NormalStageHandler(this, lv++, 13, EnemyType.Ogre, WeaponType.Gun, 4, GetRandomPosition());
        NormalStageHandler handler5 =
            new NormalStageHandler(this, lv++, 17, EnemyType.Ogre, WeaponType.Rifle, 4, GetRandomPosition());
        NormalStageHandler handler6 =
            new NormalStageHandler(this, lv++, 21, EnemyType.Ogre, WeaponType.Rocket, 4, GetRandomPosition());
        NormalStageHandler handler7 =
            new NormalStageHandler(this, lv++, 26, EnemyType.Troll, WeaponType.Gun, 5, GetRandomPosition());
        NormalStageHandler handler8 =
            new NormalStageHandler(this, lv++, 31, EnemyType.Troll, WeaponType.Rifle, 5, GetRandomPosition());
        NormalStageHandler handler9 =
            new NormalStageHandler(this, lv++, 36, EnemyType.Troll, WeaponType.Rocket, 5, GetRandomPosition());

        handler1.SetNextHandler(handler2)
            .SetNextHandler(handler3)
            .SetNextHandler(handler4)
            .SetNextHandler(handler5)
            .SetNextHandler(handler6)
            .SetNextHandler(handler7)
            .SetNextHandler(handler8)
            .SetNextHandler(handler9);
        mRootHandler = handler1;
    }
    public int GetCountOfEnemyKilled()
    {
        return mCountOfEnemyKilled;
    }

    public int countOfEnemyKilled
    {
        set => mCountOfEnemyKilled = value;
        
    }
    
    public void EnterNextStage()
    {
        // todo
        mLv++;
        mGameFacade.NotifySubject(GameEventType.NewStage);
    }

    public Vector3 targetPosition => mTargetPosition;
}