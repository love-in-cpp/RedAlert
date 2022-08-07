public class ISceneState
{
    protected SceneStateController mController;

    public ISceneState(string sceneName, SceneStateController controller)
    {
        SceneName = sceneName;
        mController = controller;
    }

    public string SceneName { get; }

    //每次进入到这个状态的时候调用
    public virtual void StateStart()
    {
    }

    public virtual void StateEnd()
    {
    }

    public virtual void StateUpdate()
    {
    }
}