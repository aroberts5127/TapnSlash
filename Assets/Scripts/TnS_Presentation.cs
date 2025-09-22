using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TnS_Presentation : MonoBehaviour {

    //[SerializeField]
    //private Button m_AtkButton;

    [SerializeField]
    private HealthBar priv_HealthBar_go;
    [SerializeField]
    private TextMeshProUGUI priv_LevelText_go;
    

    public HealthBar HealthBar
    {
        get { return priv_HealthBar_go; }
    }
    public TextMeshProUGUI LevelText
    {
        get { return priv_LevelText_go; }
    }
	// Use this for initialization
	void Start () {
        if(!TnS_GlobalSettings.RELEASE_VERSION)
            UIEventController.Instance.NameUpdateFunc(TnS_Globals.Instance.UE_AccountName);
        else
            UIEventController.Instance.NameUpdateFunc("USER");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
