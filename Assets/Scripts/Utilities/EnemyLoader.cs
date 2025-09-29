using System.Collections;
using System.Collections.Generic;
using Unity.Serialization.Json;
using UnityEngine;
using System.IO;
using System;
using UnityEditor.SearchService;


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
        //Debug.Log(enemyList.enemies.Length);
        foreach (EnemyData enemy in enemyList.enemies)
        {
            //Debug.Log(enemy.id);
            //Debug.Log(enemy.data.spawnData.modelName);
            Debug.Log(enemy.data.dropData.droppableRates[0].ToString());
           
            EnemiesById.Add(enemy.id, enemy.data);
        }
    }

    public override object GetPrefabFromID(int id)
    {
        //base.GetPrefabFromID(id);
        EnemyInfo enemyInfo = EnemiesById[id];
        //Debug.Log(enemyInfo.spawnData.modelName);
        return enemyInfo;
    }
}
