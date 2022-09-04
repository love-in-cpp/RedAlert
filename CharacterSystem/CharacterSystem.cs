using System;
using System.Collections.Generic;
using System.Linq;

public class CharacterSystem : IGameSystem
{
    private List<ICharacter> mEnemys = new();
    private List<ICharacter> mSoldiers = new();
    
    public void AddEnemy(IEnemy enemy)
    {
        mEnemys.Add(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemys.Remove(enemy);
    }
    public void AddSolider(ISoldier solider)
    {
        mSoldiers.Add(solider);
    }

    public void RemoveEnemy(ISoldier solider)
    {
        mSoldiers.Remove(solider);
    }
    
    
    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        UpdateEnemy();
        UpdateSoldier();
        RemoveCharacterIsKilled(mEnemys);
        RemoveCharacterIsKilled(mSoldiers);
    }

    private void RemoveCharacterIsKilled(List<ICharacter> characters)
    {
        List<ICharacter> canDestroys = new List<ICharacter>();
        foreach (var character in characters)
        {
            if (character.canDestroy)
            {
                canDestroys.Add(character);
            }
        }
        foreach (var character in canDestroys)
        {
            character.Release();
            characters.Remove(character);
        }
    }

    private void UpdateEnemy()
    {
        foreach (var enemy in mEnemys)
        {
            enemy.Update();
            enemy.UpdateFSMAI(mSoldiers);
        }
    }

    private void UpdateSoldier()
    {
        foreach (var soldier in mSoldiers)
        {
            soldier.Update();
            soldier.UpdateFSMAI(mEnemys);
        }
    }
    
    public override void Release()
    {
    }
}