using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected Animation mAnim;
    protected ICharacterAttr mAttr;
    protected AudioSource mAudio;
    protected GameObject mGameObject; // 当前关联的游戏对象
    protected NavMeshAgent mNavAgent;

    protected IWeapon mWeapon;
    protected bool mIsKilled = false;
    protected bool mCanDestroy = false;
    protected float mDestroyTimer = 2f;
    
    
    public Vector3 Position
    {
        get
        {
            if (mGameObject is null)
            {
                Debug.LogError("当前ICharacter实例绑定的GameObject为空");
                return Vector3.zero;
            }

            return mGameObject.transform.position;
        }
    }

    public float AtkRange => mWeapon.AtkRange;
    public ICharacterAttr attr
    {
        set => mAttr = value;
    }

    public bool canDestroy => mCanDestroy;

    public GameObject gameObject
    {
        set
        {
            mGameObject = value;
            mNavAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudio = mGameObject.GetComponent<AudioSource>();
            mAnim = mGameObject.GetComponentInChildren<Animation>();
        }
    }

    public IWeapon weapon
    {
        set
        {
            mWeapon = value;
            mWeapon.owner = this;
            // Transform weaponPoint = mGameObject.transform.Find("") // 需要提供精确路径，麻烦
            // 遍历实现 
            GameObject weaponPoint = UnityTool.FindChild(mGameObject, "weapon-point");
            UnityTool.Attach(weaponPoint, mWeapon.gameObject);
        }
    }

    public abstract void UpdateFSMAI(List<ICharacter> targets);
    public void Update()
    {
        if (mIsKilled)
        {
            mDestroyTimer -= Time.deltaTime;
            if (mDestroyTimer <= 0)
            {
                mCanDestroy = true;
            }
        }
        
        mWeapon.Update();
    }
    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.Position);
        mGameObject.transform.LookAt(target.Position);
        PlayAnim("attack");
        target.UnderAttack(mWeapon.Atk + mAttr.critValue);
    }

    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDamage(damage);
        
        // 被攻击的效果 （没有被攻击的音效）、视效
        
        // 死亡效果 音效、视效 （只有战士有）
        
    }

    public void Killed()
    {
        mIsKilled = true;
        mNavAgent.isStopped = true;
    }

    public void Release()
    {
        Object.Destroy(mGameObject);
    }
    protected void DoPlayEffect(string effectName)
    {
        // 加载特效
        GameObject effectGO = FactoryManager.assetFactory.LoadEffect(effectName); // 特效的游戏物体
        effectGO.transform.position = Position;
        // 控制销毁 协程 Todo 在特效身上添加腳本
        effectGO.AddComponent<DestroyForTime>();

    }
    protected void DoPlaySound(string soundName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(soundName);
        mAudio.clip = clip;
        mAudio.Play();
    }

    public void PlayAnim(string animName)
    {
        mAnim.CrossFade(animName);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        mNavAgent.SetDestination(targetPosition);
        PlayAnim("move");
    }
    
}