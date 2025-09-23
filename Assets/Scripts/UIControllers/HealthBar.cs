using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image healthBarImage;
    [SerializeField]
    private TextMeshProUGUI healthBarText;

    private void Start()
    {
        UIEventController.Instance.HealthUpdate += SetData;
    }

    public void SetData(int curHealth, int maxHealth)
    {
        healthBarImage.fillAmount = (float)curHealth/(float)maxHealth;
        healthBarText.text = curHealth.ToString() + "/" + maxHealth.ToString();
    }
}
