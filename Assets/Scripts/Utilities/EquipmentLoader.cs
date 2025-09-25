using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEditor;
using UnityEngine;

public class EquipmentLoader : DataLoader
{
    public Dictionary<int, EquipmentInfo> EquipmentByIdDict;

    public EquipmentLoader()
    {
        resourceDataLocation = "Data/EquipmentData";
        EquipmentByIdDict = new Dictionary<int, EquipmentInfo>();
        LoadJSONData();
    }

    protected override void LoadJSONData()
    {
        base.LoadJSONData();
        EquipmentList EquipmentDatas = JsonUtility.FromJson<EquipmentList>(jsonFile.text);
        //Debug.Log(EquipmentDatas.ToString());
        foreach (EquipmentData item in EquipmentDatas.weapons)
        {
            //Debug.Log(item.id);
            //Debug.Log(item.data.name);
            EquipmentByIdDict.Add(item.id, item.data);
        }
        foreach (EquipmentData item in EquipmentDatas.misc)
        {
            //Debug.Log(item.id);
            //Debug.Log(item.data.name);
            EquipmentByIdDict.Add(item.id, item.data);
        }
        foreach (EquipmentData item in EquipmentDatas.armor)
        {
            //Debug.Log(item.id);
            //Debug.Log(item.data.name);
            EquipmentByIdDict.Add(item.id, item.data);
        }
        foreach (EquipmentData item in EquipmentDatas.shields)
        {
            //Debug.Log(item.id);
            //Debug.Log(item.data.name);
            EquipmentByIdDict.Add(item.id, item.data);
        }

    }

    public override object GetPrefabFromID(int id)
    {
        EquipmentInfo data = EquipmentByIdDict[id];
        //Is this where I assign the data?
        return data;
    }
}
