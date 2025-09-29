using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;


[Serializable]
public struct EnemyData
{
    public int id;
    public EnemyInfo data;
}

[Serializable]
public struct EnemyInfo
{
    public string name;
    public int health;
    public int attack;
    public int defense;
    public int experience;
    public EnemyDropData dropData;
    public int revengeValue;
    public EnemySpawnData spawnData;
}



[Serializable]
public struct EnemyDropData
{
    public int goldMin;
    public int goldMax;
    public int[] droppableIDs;
    public int[] droppableRates;
}


[Serializable]
public struct EnemySpawnData
{
    public string modelName;
    public string[] materialList;
}


[Serializable]
public struct EnemyList
{
    public EnemyData[] enemies;
}
