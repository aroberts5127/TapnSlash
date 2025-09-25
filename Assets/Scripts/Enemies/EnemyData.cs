using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
public class EnemyData
{
    public int id;
    public EnemyInfo data;
}

[Serializable]
public class EnemyInfo
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
public class EnemyDropData
{
    public int goldMin;
    public int goldMax;
    public int[] droppableIDs;
    public int[] droppableRates;
}

[Serializable]
public class EnemySpawnData
{
    public string modelName;
    public string[] materialList;
}

[Serializable]
public class EnemyList
{
    public EnemyData[] enemies;
}
