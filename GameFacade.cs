// 外观模式 中介者 单例模式

using UnityEngine;

public class GameFacade
{
    private AchievementSystem mAchievementSystem;

    private CampInfoUI mCampInfoUI;
    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private GameEventSystem mGameEventSystem;
    private GamePauseUI mGamePauseUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;
    private StageSystem mStageSystem;

    private GameFacade()
    {
    }

    public bool MGameOver { get; }

    public static GameFacade Instance { get; } = new();

    public GameFacade GetInstance()
    {
        return Instance;
    }

    public Vector3 GetEnemyTargetPosition()
    {
        return Vector3.zero;
    }
    public void Init()
    {
        mAchievementSystem = new AchievementSystem();
        mCampSystem = new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();
        mEnergySystem = new EnergySystem();

        mCampInfoUI = new CampInfoUI();
        mGamePauseUI = new GamePauseUI();
        mGameStateInfoUI = new GameStateInfoUI();
        mSoldierInfoUI = new SoldierInfoUI();

        mAchievementSystem.Init();
        mCampSystem.Init();
        mCharacterSystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();

        mCampInfoUI.Init();
        mGamePauseUI.Init();
        mGameStateInfoUI.Init();
        mSoldierInfoUI.Init();
    }

    public void Update()
    {
        mAchievementSystem.Update();
        mCampSystem.Update();
        mCharacterSystem.Update();
        mGameEventSystem.Update();
        mStageSystem.Update();
        mEnergySystem.Update();

        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }

    public void Release()
    {
        mAchievementSystem.Release();
        mCampSystem.Release();
        mCharacterSystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();
        mEnergySystem.Release();

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();
    }
    
}