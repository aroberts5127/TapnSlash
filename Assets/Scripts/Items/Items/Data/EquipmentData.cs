using EnumUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipmentData
{
    public int id;
    public EquipmentInfo data;
}

[Serializable]
public class EquipmentInfo
{
    public string name;
    public bool isDefault;
    public EquipmentModifier[] modifiers;
    public string modelName;
    public EquipmentMaterials[] modelMaterials;
}

[Serializable]
public class EquipmentList
{
    public EquipmentData[] weapons;
    public EquipmentData[] armor;
    public EquipmentData[] shields;
    public EquipmentData[] misc;
 }


[Serializable]
public class EquipmentModifier
{
    public int atk;
    public int def;
}

[Serializable]
public class EquipmentMaterials
{
    public string mainMat;
}
