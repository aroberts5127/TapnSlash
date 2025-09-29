using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_Inventory : MonoBehaviour {

    public List<TnS_Item> itemList = new List<TnS_Item>();
    public Dictionary<int, int> itemDict = new Dictionary<int, int>();
    public List<EquipmentData> equipmentList = new List<EquipmentData>();
    public int Gold = 0;

    public void AddItem(TnS_Item item)
    {
        int count = 1;
        if (itemDict.ContainsKey(item.itemData.id))
        {
            count = itemDict[item.itemData.id] + 1;
            itemDict[item.itemData.id] = count;
            return;
        }
        itemDict.Add(item.itemData.id, count);
    }

    public void AddEquipment(EquipmentData equipment)
    {
        EquipmentData d = new EquipmentData();
        d.id = equipment.id;
        d.data = equipment.data;
        equipmentList.Add(d);
    }

    public void RemoveItem(TnS_Item item)
    {
        if (itemDict[item.itemData.id] > 0)
        {
            itemDict[item.itemData.id] -= 1;
        }
        else
        {
            Debug.LogError("Somehow using an item with a count of 0");
        }
    }

    public void RemoveEquipment(EquipmentData equipment)
    {
        int v = itemList.Count;
        equipmentList.Remove(equipment);
        if (v != itemList.Count)
        {
            Debug.Log("Successfully Removed Item");
        }
    }

    public void CollectGold(int g)
    {
        Gold += g;
    }


    /// <summary>
    /// Removes gold from inventory.
    /// Shops will check to see if you have enough gold to spend and won't allow you to purchase items that would take your gold below 0
    /// Check for g >= Gold is for potential Stolen, Misplaced, or otherwise lost (not spent) gold.
    /// </summary>
    /// <param name="g"></param>
    public void ReduceGold(int g)
    {
        if (g >= Gold)
            Gold = 0;
        else
        {
            Gold -= g;
        }
    }

}
