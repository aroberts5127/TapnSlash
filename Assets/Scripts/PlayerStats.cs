using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.CompilerServices;

public class PlayerStats : MonoBehaviour
{
    #region Base Stats
    [SerializeField]
    private int priv_MaxHealth;
    [SerializeField]
    private int priv_Attack;
    [SerializeField]
    private int priv_Defense;
    #endregion

    #region Applied Stats
    [SerializeField]
    private int _appliedMaxHealth;
    [SerializeField]
    private int _appliedAttack;
    [SerializeField]
    private int _appliedDefense;
    #endregion

    #region Misc Stats
    private int priv_CurrentHealth;
    private int priv_Level;
    private int priv_CurrentExperience;
    private int priv_ExpToNextLevel;
    #endregion


    #region PUBLIC STAT VARS
    public int PC_MaxHealth
    {
        get { return _appliedMaxHealth; }
        set { _appliedMaxHealth = value; }
    }

    public int PC_CurrentHealth
    {
        get { return priv_CurrentHealth; }
        set { priv_CurrentHealth = value; }
    }
    public int PC_Attack
    {
        get { return _appliedAttack; }
    }
    public int PC_Defense
    {
        get { return _appliedDefense; }
    }

    public int PC_Level
    {
        get { return priv_Level; }
        set { priv_Level = value; }
    }
    public int CurrentExperience
    {
        get { return priv_CurrentExperience; }
        set { priv_CurrentExperience = value; }
    }
    public int ExpToNextLevel
    {
        get { return priv_ExpToNextLevel; }
        set { priv_ExpToNextLevel = value; }
    }
    #endregion

    public void TakeOrHealDamage(int healthChange)
    {
        priv_CurrentHealth += healthChange;
        if (priv_CurrentHealth <= _appliedMaxHealth * 0.2)
        {
            Debug.Log("Here");
            UIEventController.Instance.LowHealthEventFunc(true);
        }
        else
        {
            UIEventController.Instance.LowHealthEventFunc(false);
        }
        if (priv_CurrentHealth <= 0)
        {
            priv_CurrentHealth = 0;
            //DIE
        }
        if(priv_CurrentHealth > _appliedMaxHealth)
        {
            priv_CurrentHealth = _appliedMaxHealth;
        }
        UIEventController.Instance.HealthUpdateFunc(priv_CurrentHealth, _appliedMaxHealth);
    }


    private void CalculateAppliedStats()
    {
        _appliedMaxHealth = priv_MaxHealth;
    }




    #region LEVEL STUFF
    public void AwardExp(int expAdded)
    {
        CurrentExperience += expAdded;
        if (CurrentExperience >= ExpToNextLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {

        PC_Level++;
        Debug.Log("Tns_PlayerCharacter - Level Up: " + PC_Level);
        if (CurrentExperience > ExpToNextLevel)
        {
            CurrentExperience = ExpToNextLevel - CurrentExperience;
        }
        else
        {
            CurrentExperience = 0;
        }
        ExpToNextLevel = (int)(ExpToNextLevel * 1.2f);
        TnS_Globals.Instance.Player.UpdateLevelDisplay();
        //MODIFY BASE STATS
        //Base Health, Base Attack, Base Defense, ExpToNextLevel
        //READ IN JSON, GET LEVEL FROM A DICTIONARY WITH LEVEL AS INDEX
    }
    #endregion
}
