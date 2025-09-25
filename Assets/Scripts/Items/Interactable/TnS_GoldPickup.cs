using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_GoldPickup : TnS_Interactable {

    public int goldValue = 1;

    public void Start()
    {
        StartCoroutine(AutoCollect());
    }


    public override void Interact()
    {
        base.Interact();
        //Debug.Log("INTERACTABLE - Collecting " + goldValue + " Gold");
        CollectGold();
    }

    private void CollectGold()
    {
        TnS_Globals.Instance.Inventory.CollectGold(goldValue);
    }

    private IEnumerator AutoCollect()
    {
        yield return new WaitForSeconds(3.0f); //Value to be put in a config file somewhere
        Interact();
    }

}
