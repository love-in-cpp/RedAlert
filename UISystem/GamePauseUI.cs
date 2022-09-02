using System;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : IBaseUI
{
    private Text mCurrentStageLv;
    private Button mContinueBtn;
    private Button mBackMenuBtn;
    
    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GamePauseUI");
        
        mCurrentStageLv = UITool.FindChild<Text>(mRootUI, "CurrentStageLv");
        mContinueBtn = UITool.FindChild<Button>(mRootUI, "ContinueBtn");
        mBackMenuBtn = UITool.FindChild<Button>(mRootUI, "BackBtn");
        
        Hide();
    }

    public override void Update()
    {
    }

    public override void Release()
    {
    }
}