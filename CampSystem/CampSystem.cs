using System;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;


public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();

    private Dictionary<EnemyType, CaptiveCamp> mCaptiveCamps = new Dictionary<EnemyType, CaptiveCamp>();
    public override void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);
        InitCamp(EnemyType.Elf);
    }

    public override void Update()
    {
        // 更新所有兵营内部游戏逻辑
        foreach (var camp in mSoldierCamps.Values)
        {
            camp.Update();
        }

        foreach (var value in mCaptiveCamps.Values)
        {
            value.Update();
        }
    }

    public override void Release()
    {
    }

    private void InitCamp(SoldierType soldierType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string icon = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0;
        
        switch (soldierType)
        {
            case SoldierType.Rookie:
                gameObjectName = "SoldierCamp_Rookie";
                name = "新手兵营";
                icon = "RookieCamp";
                trainTime = 3;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                icon = "SergeantCamp";
                trainTime = 4;
                break;
            case SoldierType.Captain:
                gameObjectName = "SoldierCamp_Captain";
                name = "上尉兵营";
                icon = "CaptainCamp";
                trainTime = 5;
                break;
            default:
                Debug.LogError("无法根据战士类型"+soldierType+"初始化兵营");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        position = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(gameObject, name, icon, soldierType, position, trainTime);

        CampOnClick campOnClick = gameObject.AddComponent<CampOnClick>(); //todo 继承自Monobehaviour的脚本组件，挂载在游戏物体上后，会返回这个脚本组件的实例化对象。
        campOnClick.camp = camp;
        
        mSoldierCamps.Add(soldierType,camp);
    }

    private void InitCamp(EnemyType enemyType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string icon = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0;
        
        switch (enemyType)
        {
            case EnemyType.Elf:
                gameObjectName = "CaptiveCamp_Elf";
                name = "俘兵营";
                icon = "CaptiveCamp";
                trainTime = 3;
                break;
            default:
                Debug.LogError("无法根据敌人类型"+enemyType+"初始化兵营");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        position = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
        CaptiveCamp camp = new CaptiveCamp(gameObject, name, icon, enemyType, position, trainTime);

        CampOnClick campOnClick = gameObject.AddComponent<CampOnClick>(); //todo 继承自Monobehaviour的脚本组件，挂载在游戏物体上后，会返回这个脚本组件的实例化对象。
        campOnClick.camp = camp;
        
        mCaptiveCamps.Add(enemyType,camp);   
    }
}