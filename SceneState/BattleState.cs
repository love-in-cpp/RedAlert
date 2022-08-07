public class BattleState : ISceneState
{
    private readonly GameFacade mFacade = GameFacade.Instance; // 单例模式  

    public BattleState(SceneStateController controller) : base("03BattleScene", controller)
    {
    }

    public override void StateStart()
    {
        mFacade.Init();
    }

    public override void StateUpdate()
    {
        if (mFacade.MGameOver) mController.SetState(new MainMenuState(mController));
        mFacade.Update();
    }

    public override void StateEnd()
    {
        mFacade.Release();
    }
}