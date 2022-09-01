using UnityEngine;

public abstract class ICamp
{
    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;
    protected Vector3 mPosition; // 集合点

    public ICamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mPosition = position;
    }

}