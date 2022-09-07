using UnityEngine;

public class AchievenmentMemento
{
    // 本成就系统只保存一些最大数据
    public int enemyKilledCount { get; set; }
    public int soldierKilledCount{ get; set; }
    public int maxStageLv{ get; set; }

    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKilledCount", enemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", soldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLv", maxStageLv);
    }

    public void LoadData()
    {
        enemyKilledCount=PlayerPrefs.GetInt("EnemyKilledCount" );
        soldierKilledCount=PlayerPrefs.GetInt("SoldierKilledCount" );
        maxStageLv=PlayerPrefs.GetInt("MaxStageLv" );
    }
    
}