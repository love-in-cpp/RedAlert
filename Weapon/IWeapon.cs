using UnityEngine;

public enum WeaponType
{
    Gun,
    Rifle,
    Rocket,
    MAX,
}

public abstract class IWeapon
{
    protected WeaponBaseAttr mBaseAttr;
    // protected int mAtkPlusValue;
    
    protected AudioSource mAudio;

    protected float mEffectDisplayTime;


    protected GameObject mGameObject; // 武器对象本体
    protected Light mLight;
    protected LineRenderer mLine;
    protected ICharacter mOwner; // 武器拥有者
    protected ParticleSystem mParticle;

    public float AtkRange => mBaseAttr.atkRange;
    public int Atk => mBaseAttr.atk;

    public ICharacter owner
    {
        set => mOwner = value;
    }

    public GameObject gameObject => mGameObject;

    public IWeapon(WeaponBaseAttr baseAttr, GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;

        Transform effect = mGameObject.transform.Find("Effect");
        mParticle = effect.GetComponent<ParticleSystem>();
        mLine = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudio = effect.GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (mEffectDisplayTime > 0)
            mEffectDisplayTime -= Time.deltaTime;
        else
            DisableEffct();
    }

    public virtual void Fire(Vector3 targetPosition)
    {
        // 显示枪口特效
        PlayMuzzleEffect();

        // 显示子弹轨迹特效
        PlayBulletEffect(targetPosition);

        // 设置特效显示时间
        SetEffectDisplayTime();

        // 播放声音
        PlaySound();
    }

    protected abstract void SetEffectDisplayTime();
    protected abstract void PlayBulletEffect(Vector3 targetPosition);
    protected abstract void PlaySound();

    protected virtual void PlayMuzzleEffect()
    {
        mParticle.Stop();
        mParticle.Play();
        mLight.enabled = true;
    }

    protected void DoPlayBulletEffect(float width, Vector3 targetPosition)
    {
        mLine.enabled = true;
        mLine.startWidth = width;
        mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPosition);
    }

    protected void DoPlaySound(string clipName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(clipName); 
        mAudio.clip = clip;
        mAudio.Play();
    }

    private void DisableEffct()
    {
        mLine.enabled = false;
        mLight.enabled = false;
    }
}