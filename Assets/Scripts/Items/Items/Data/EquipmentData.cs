using EnumUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct EquipmentData
{
    public int id;
    public EquipmentInfo data;
}

[Serializable]
public struct EquipmentInfo
{
    public string name;
    public bool isDefault;
    public EnumEquipmentSlot slot;
    public EquipmentAttributes baseAttributes;
    public string modelName;
    public EquipmentMaterials modelMaterials;
    public EquipmentModifiers equipmentModifiers;
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
public struct EquipmentAttributes
{
    public int minAtk;
    public int maxAtk;
    public int minDef;
    public int maxDef;
    public int atk;
    public int def;
}

[Serializable]
public struct EquipmentMaterials
{
    public string mainMat;
}

[Serializable]
public struct EquipmentModifiers
{
    public Modifier[] availableModifiers;
    public Modifier[] appliedModifiers;
}
