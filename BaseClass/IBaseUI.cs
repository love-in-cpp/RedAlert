using UnityEngine;

public abstract class IBaseUI
{
    public GameObject mRootUI;
    // 抽象类是为基类而生的，virtual是多态的应用
    public virtual void Init()
    {
        
    }

    public virtual void Update()
    {
        
    }

    public virtual void Release()
    {
        
    }

    protected void Show()
    {
        mRootUI.SetActive(true);
    }

    protected void Hide()
    {
        mRootUI.SetActive(false);
    }
}