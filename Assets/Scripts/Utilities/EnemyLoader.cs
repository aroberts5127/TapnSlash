using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : DataLoader
{
    public Dictionary<int, EnemyInfo> EnemiesById;

    public EnemyLoader()
    {
        resourceDataLocation = "Data/EnemyData";
        EnemiesById = new Dictionary<int, EnemyInfo>();
        LoadJSONData();
    }

    protected override void LoadJSONData()
    {
        base.LoadJSONData();
        EnemyList enemyList = JsonUtility.FromJson<EnemyList>(jsonFile.text);
        foreach (EnemyData enemy in enemyList.enemies)
        {
            Debug.Log(enemy.id);
            Debug.Log(enemy.data.spawnData.modelName);
            EnemiesById.Add(enemy.id, enemy.data);
        }
    }

    public override object GetPrefabFromID(int id)
    {
        //base.GetPrefabFromID(id);
        EnemyInfo enemyInfo = EnemiesById[id];
        Debug.Log(enemyInfo.spawnData.modelName);
        return enemyInfo;
    }
}
