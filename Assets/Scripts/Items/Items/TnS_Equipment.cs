using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumUtil;
using System.Data;


public class TnS_Equipment : MonoBehaviour {
    
    public EquipmentData data;
    public EnumEquipmentSlot equipSlot;

    private void Start()
    {
        data = new EquipmentData();
    }

    public void SetData(EquipmentData d)
    {
        data = d;

    }

    public string WeaponName
    {
        get { return data.data.name; }
    }

    public void Use()
    {
        
    }
}


