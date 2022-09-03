using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ICamp
{
    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;
    protected Vector3 mPosition; // 集合点
    protected float mTrainTime;

    protected List<ITrainCommand> mCommands;
    private float mTrainTimer = 0;
    public ICamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mPosition = position;
        mTrainTime = trainTime;
        mTrainTimer = mTrainTime;

        mCommands = new List<ITrainCommand>();
    }

    public virtual void Update()
    {
        UpdateCommand();
    }

    private void UpdateCommand()
    {
        if (mCommands.Count <= 0)return;
        mTrainTimer -= Time.deltaTime;
        if (mTrainTimer <= 0)
        {
            mCommands[0].Execute();
            mCommands.RemoveAt(0);
            mTrainTimer = mTrainTime;
        }
    }

    public string name => mName;
    public string iconSprite => mIconSprite;
    public abstract int lv { get; }
    public abstract WeaponType weaponType { get; }

    public abstract void Train();

    public void CancelTrainCommand()
    {
        if (mCommands.Count > 0)
        {
            mCommands.RemoveAt(mCommands.Count-1);
            // Timer重置！!
            if (mCommands.Count == 0)
            {
                mTrainTimer = mTrainTime;
            }
        }
    }
}