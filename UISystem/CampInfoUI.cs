﻿
using System;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class CampInfoUI : IBaseUI
{
    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLevel;
    private Text mWeaponLevel;
    private Button mCampUpgradeBtn;
    private Button mWeaponUpgradeBtn;
    private Button mTrainBtn;
    private Button mCancelTrainBtn;
    private Text mAliveCount;
    private Text mTrainingCount;
    private Text mTrainTime;

    private ICamp mCamp;
    
    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");

        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mCampLevel = UITool.FindChild<Text>(mRootUI, "CampLv");
        mWeaponLevel = UITool.FindChild<Text>(mRootUI, "WeaponLv");
        mCampUpgradeBtn = UITool.FindChild<Button>(mRootUI, "CampUpgradeBtn");
        mWeaponUpgradeBtn = UITool.FindChild<Button>(mRootUI, "WeaponUpgradeBtn");
        mTrainBtn = UITool.FindChild<Button>(mRootUI, "TrainBtn");
        mCancelTrainBtn = UITool.FindChild<Button>(mRootUI, "CancelTrainBtn");
        mAliveCount = UITool.FindChild<Text>(mRootUI, "AliveCount");
        mTrainingCount = UITool.FindChild<Text>(mRootUI, "TrainingCount");
        mTrainTime = UITool.FindChild<Text>(mRootUI, "TrainTime");
        
        Hide();
        
    }

    public override void Update()
    {
    }

    public override void Release()
    {
    }

    public void ShowCampInfo(ICamp camp)
    {
        mCamp = camp; // 用做和被点击的camp进行交互
        
        mCampIcon.sprite = FactoryManager.assetFactory.LoadSprite(camp.iconSprite);
        mCampName.text = camp.name;
        mCampLevel.text = camp.lv.ToString();
        ShowWeaponLevel(camp.weaponType);
        Show();
    }

    private void ShowWeaponLevel(WeaponType campWeaponType)
    {
        switch (campWeaponType)
        {
            case WeaponType.Gun:
                mWeaponLevel.text = "短枪";
                break;
            case WeaponType.Rifle:
                mWeaponLevel.text = "长枪";
                break;
            case WeaponType.Rocket:
                mWeaponLevel.text = "火箭";
                break;
            case WeaponType.MAX:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(campWeaponType), campWeaponType, null);
        }
    }
}