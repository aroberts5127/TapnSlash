using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_Enemy : MonoBehaviour, iDamagable {

    #region VARIABLES

    #region Private Variables

    [SerializeField]
    private string priv_Name;
    [SerializeField]
    private int priv_Health;
    [SerializeField]
    private int priv_Attack;
    [SerializeField]
    private int priv_Defense;

    [SerializeField]
    private int priv_ExperienceReward;

    [SerializeField]
    private TextMesh priv_NameTextObj;

    //[SerializeField]
    //private List<TnS_Interactable> priv_DroppableItems;
    [SerializeField]
    private List<int> priv_DroppableItemsByID;
    [SerializeField]
    private List<float> priv_DroppableItemRates;
    [SerializeField]
    private int priv_GoldDropValueMin;
    [SerializeField]
    private int priv_GoldDropValueMax;


    private int priv_EnemyRevengeValue;
    private bool isDying = false;
    private bool isAttacking = false;
    #endregion

    #region Getter/Setter
    public string Name
    {
        get { return priv_Name; }
    }
    public int Health
    {
        get { return priv_Health; }
        set { priv_Health = value; }
    }
    public int Attack
    {
        get { return priv_Attack; }
    }
    public int Defense
    {
        get { return priv_Defense; }
    }
    public int ExpReward
    {
        get { return priv_ExperienceReward; }
    }

    public bool Dying
    {
        get { return isDying; }
    }
    #endregion

    #endregion

    void Awake()
    {
        
    }

    void Start () {
        priv_NameTextObj.text = this.priv_Name;
        EncounterEventController.Instance.playerAttackEvent += TakeDamage;
        priv_EnemyRevengeValue = 1;
	}	
	void Update () {
		if(priv_EnemyRevengeValue <= TnS_Globals.Instance.GlobalEnemyRevengeValue)
        {
            EnemyAttack();
        }
	}

    public void SetData(EnemyInfo data)
    {
        priv_Name = data.name;
        priv_NameTextObj.text = priv_Name;
        priv_Attack = data.attack;
        priv_Defense = data.defense;
        priv_Health = data.health;
        priv_ExperienceReward = data.experience;
        priv_EnemyRevengeValue = data.revengeValue;
        for (int i = 0; i < data.dropData.droppableRates.Length; i++)
        {
            priv_DroppableItemsByID.Add(data.dropData.droppableIDs[i]);
            priv_DroppableItemRates.Add((float)data.dropData.droppableRates[i]);
        }
        priv_GoldDropValueMin = data.dropData.goldMin;
        priv_GoldDropValueMax = data.dropData.goldMax;
    }
    private void EnemyAttack()
    {
        isAttacking = true;
        //TODO - Enemy Attack
        //TODO - Initiate Player Dodge/Guard Chance
        //TODO - ENEMY CANNOT ALWAYS BE DEFENDED AGAINST!
        EncounterEventController.Instance.OnEnemyAttack(Attack);
        TnS_Globals.Instance.Player.UpdateHealthBar();
    }

    public void TakeDamage(int incDamage)
    {
        if (!isAttacking)
            this.GetComponent<Animator>().Play("damage");
        Health = Health - incDamage;
        if(Health <= 0)
        {
            StartCoroutine(Die());
        }
    }
    public IEnumerator Die()
    {
        isDying = true;
        this.GetComponent<Animator>().speed = 2.0f;
        this.GetComponent<Animator>().Play("die");

        //THIS NEEDS TO BE MOVED TO EVENTS
        TnS_Globals.Instance.Player.AwardExp(this.ExpReward);
        DropItems();
        yield return new WaitForSeconds(2.0f);
        EncounterEventController.Instance.playerAttackEvent -= TakeDamage;
        EncounterEventController.Instance.OnEnemyDead();
        Destroy(this.gameObject);
    }
    public void DropItems()
    {
        //Debug.Log("ENEMY - Dropping Items");
        for (int i = 0; i < priv_DroppableItemsByID.Count; i++)
        {
            if (priv_DroppableItemRates[i] == 100)
            {
                GenerateItem(priv_DroppableItemsByID[i]);
            }
            else
            {
                float r = UnityEngine.Random.Range(0, 1);
                if (0 <= r && r <= priv_DroppableItemRates[i] / 100)
                {
                    GenerateItem(priv_DroppableItemsByID[i]);
                }
            }
        }
    }

    private void GenerateItem(int id)
    {
        EquipmentInfo prefab = (EquipmentInfo)TnS_Globals.Instance.EquipmentLoader.GetPrefabFromID(id);
        GameObject newItem = Instantiate(Resources.Load<GameObject>("DropItemPrefabs/"+prefab.modelName), TnS_Globals.Instance.LootSpawn, false);
        if (id == 4)
        {
            int goldDropValue = UnityEngine.Random.Range(priv_GoldDropValueMin, priv_GoldDropValueMax);
            newItem.GetComponent<TnS_GoldPickup>().goldValue = goldDropValue;
        }
        else //This needs to be segmented differently!!!!
        {
            newItem.GetComponent<TnS_WeaponPickup>().SetData(id, prefab);
        }
        newItem.transform.position = TnS_Globals.Instance.LootSpawn.position;
    }
}
