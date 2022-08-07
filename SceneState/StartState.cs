using UnityEngine;
using UnityEngine.UI;

public class StartState : ISceneState
{
    private Image mLogo;
    private readonly float mSmoothingSpeed = 1;
    private float mWaitTime = 2;

    public StartState(SceneStateController controller) : base("01StartScene", controller)
    {
    }

    public override void StateStart()
    {
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
        mLogo.color = Color.black;
    }

    public override void StateUpdate()
    {
        mLogo.color = Color.Lerp(mLogo.color, Color.white, mSmoothingSpeed * Time.deltaTime);
        mWaitTime -= Time.deltaTime;
        if (mWaitTime <= 0) mController.SetState(new MainMenuState(mController));
    }
}