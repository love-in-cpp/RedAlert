using System.Collections.Generic;
using UnityEngine;

public class ResourceAssetProxyFactory:IAssetFactory
{
    private ResourcesAssetFactory mAssetFactory = new ResourcesAssetFactory();
    private Dictionary<string, GameObject> mSoldiers = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEnemys = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mWeapons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEffects = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> mAudioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> mSprites = new Dictionary<string, Sprite>();
    public GameObject LoadSoldier(string name)
    {
        if (mSoldiers.ContainsKey(name))
        {
            return GameObject.Instantiate(mSoldiers[name]); // 这里要Instantiate ，为什么?Todo
        }
        
        // mAssetFactory.LoadSoldier(name); // 不能这样实例化，先得到资源，把资源放进字典再实例化
        
         GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.SoldierPath + name) as GameObject;
         mSoldiers.Add(name, asset);
         return Object.Instantiate(asset);
    }

    public GameObject LoadEnemy(string name)
    {
        if (mEnemys.ContainsKey(name))
        {
            return GameObject.Instantiate(mEnemys[name]); // 这里要Instantiate ，为什么?Todo
        }
        
        // mAssetFactory.LoadSoldier(name); // 不能这样实例化，先得到资源，把资源放进字典再实例化
        
        GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EnemyPath + name) as GameObject;
        mEnemys.Add(name, asset);
        return Object.Instantiate(asset);
    }

    public GameObject LoadWeapon(string name)
    {
        if (mWeapons.ContainsKey(name))
        {
            return GameObject.Instantiate(mWeapons[name]); // 这里要Instantiate ，为什么?Todo
        }
        
        // mAssetFactory.LoadSoldier(name); // 不能这样实例化，先得到资源，把资源放进字典再实例化
        
        GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.WeaponPath + name) as GameObject;
        mWeapons.Add(name, asset);
        return Object.Instantiate(asset);
    }

    public GameObject LoadEffect(string name)
    {
        if (mEffects.ContainsKey(name))
        {
            return GameObject.Instantiate(mEffects[name]); // 这里要Instantiate ，为什么?Todo
        }
        
        // mAssetFactory.LoadSoldier(name); // 不能这样实例化，先得到资源，把资源放进字典再实例化
        
        GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EffectPath + name) as GameObject;
        mEffects.Add(name, asset);
        return Object.Instantiate(asset);
    }

    public AudioClip LoadAudioClip(string name)
    {
        // 不需要实例化
        if (mAudioClips.ContainsKey(name))
        {
            return GameObject.Instantiate(mAudioClips[name]); // 这里要Instantiate ，为什么?Todo
        }

        AudioClip audioClip = mAssetFactory.LoadAudioClip(name);
        mAudioClips.Add(name, audioClip);
        return audioClip;
    }

    public Sprite LoadSprite(string name)
    {
        // 不需要实例化
        if (mSprites.ContainsKey(name))
        {
            return GameObject.Instantiate(mSprites[name]); // 这里要Instantiate ，为什么?Todo
        }

        Sprite sprite = mAssetFactory.LoadSprite(name);
        mSprites.Add(name, sprite);
        return sprite;
    }
}