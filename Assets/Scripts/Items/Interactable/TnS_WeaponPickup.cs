using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_WeaponPickup : TnS_Interactable {

    public EquipmentData eData;

    // Create Atk and Def Values from min-max in EquipmentAttributes.
	public void SetData(int id, EquipmentInfo data)
    {
        eData.id = id;
        data.baseAttributes.atk = Random.Range(data.baseAttributes.minAtk, data.baseAttributes.maxAtk);
        data.baseAttributes.def = Random.Range(data.baseAttributes.minDef, data.baseAttributes.maxDef);
        eData.data = data;
    }
	
    public override void Interact()
    {
        CollectWeapon();// weapon);
        base.Interact();     
    }

    private void CollectWeapon()
    {
        TnS_Globals.Instance.Inventory.AddEquipment(eData);
    }
}
