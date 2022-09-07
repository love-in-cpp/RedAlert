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
        return mStageSystem.targetPosition;
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
        mEnergySystem.Init();

        mCampInfoUI.Init();
        mGamePauseUI.Init();
        mGameStateInfoUI.Init();
        mSoldierInfoUI.Init();
        
        LoadMemento();
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
        
        CreatMemento();
    }

    public void ShowCampInfo(ICamp camp)
    {
      mCampInfoUI.ShowCampInfo(camp);
    }

    public void AddSoldier(ISoldier soldier)
    {
        mCharacterSystem.AddSolider(soldier);
    }

    public void AddEnemy(IEnemy enemy)
    {
        mCharacterSystem.AddEnemy(enemy);
    }

    public bool TakeEnergy(int value)
    {
        return mEnergySystem.TakeEnergy(value);
    }

    public void RecycleEnergy(int value)
    {
        mEnergySystem.Recycle(value);
    }

    public void ShowMsg(string msg)
    {
        mGameStateInfoUI.ShowMsg(msg);
    }

    public void UpdateEnergySlider(int nowEnergy, int maxEnergy)
    {
        mGameStateInfoUI.UpdateEnergySlider(nowEnergy,maxEnergy);
    }

    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RegisterObserver(eventType,observer);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RemoveObserver(eventType, observer);
    }

    public void NotifySubject(GameEventType eventType)
    {
        mGameEventSystem.NotifySubject(eventType);
    }

    private void LoadMemento()
    {
        AchievenmentMemento memento = new AchievenmentMemento();
        memento.LoadData();
        mAchievementSystem.SetMemento(memento);
    }

    private void CreatMemento()
    {
        mAchievementSystem.CreateMemento().SaveData();
    }
    
    
}