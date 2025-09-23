using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class TnS_EquipmentSO : ScriptableObject
{
    new public string name = "New Equipment";
    public Sprite icon = null;
    public bool isDefault = false;
    public GameObject itemMesh = null;

}
