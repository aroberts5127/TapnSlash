using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_EnemySpawner : MonoBehaviour
{
    public static TnS_EnemySpawner Instance;

    Dictionary<int, List<TnS_Enemy>> enemiesPerLevelList; //TODO - Get This in Place
    
    void Start()
    {
        EncounterEventController.Instance.enemyDeathEvent += SpawnEnemy;
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        int r = Random.Range(0, TnS_Globals.Instance.AvailableEnemies.Count);
        EnemyInfo prefab = TnS_Globals.Instance.EnemyLoader.GetPrefabFromID(TnS_Globals.Instance.AvailableEnemies[r]) as EnemyInfo;
        Debug.Log(prefab.spawnData.modelName);
        GameObject newEnemy = Instantiate(Resources.Load<GameObject>("EnemyPrefabs/" + prefab.spawnData.modelName));
        newEnemy.transform.position = TnS_Globals.Instance.EnemySpawnLocation.position;
        newEnemy.transform.parent = TnS_Globals.Instance.EnemySpawnParent;
        TnS_Enemy enemy = newEnemy.GetComponent<TnS_Enemy>();
        enemy.SetData(prefab);
        TnS_Globals.Instance.CurrentEnemy = enemy;
    }
}
