using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    private AsyncOperation mAO;
    private bool mIsRunStart;
    private ISceneState mState;

    public void SetState(ISceneState state, bool isLoadScene = true)
    {
        if (mState != null) mState.StateEnd(); //让上一个场景状态做一下清理工作
        mState = state;
        if (isLoadScene)
        {
            mAO = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsRunStart = false;
        }
        else
        {
            mState.StateStart();
            mIsRunStart = true;
        }
    }

    public void StateUpdate()
    {
        if (mAO != null && mAO.isDone == false) return;

        if (mIsRunStart == false && mAO != null && mAO.isDone)
        {
            mState.StateStart();
            mIsRunStart = true;
        }

        if (mState != null) mState.StateUpdate();
    }
}