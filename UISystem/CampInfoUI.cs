
using System;
using System.Globalization;
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
        
        mTrainBtn.onClick.AddListener(OnTrainCLick);
        mCancelTrainBtn.onClick.AddListener(OnCancelTrainClick);
        Hide();
        
    }

    public override void Update()
    {
        base.Update();
        if (mCamp is not null)
        {
            ShowTrainingInfo();
        }
        
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
        
        ShowTrainingInfo();
        Show();
    }

    private void ShowTrainingInfo()
    {
        mTrainTime.text = mCamp.remainingTrainTime.ToString(CultureInfo.CurrentCulture);
        mTrainingCount.text = mCamp.trainCount.ToString();
        if (mCamp.trainCount <= 0)
        {
            mCancelTrainBtn.interactable = false;
        }
        else
        {
            mCancelTrainBtn.interactable = true;
        }
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

    public void OnTrainCLick()
    {
        // todo 能量是否足够 
        mCamp.Train();
    }

    public void OnCancelTrainClick()
    {
        // 回收能量 todo
        mCamp.CancelTrainCommand();
    }
}