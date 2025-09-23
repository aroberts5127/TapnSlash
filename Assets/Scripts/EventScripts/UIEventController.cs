using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventController : MonoBehaviour
{

    public static UIEventController Instance;

    public event Action<int, int> HealthUpdate;
    public event Action<string> NameUpdate;
    public event Action<bool> LowHealthEvent;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    public void HealthUpdateFunc(int curHealth, int maxHealth)
    {
        HealthUpdate?.Invoke(curHealth, maxHealth);
    }

    public void NameUpdateFunc(string name) {   
        NameUpdate?.Invoke(name); 
    }

    public void LowHealthEventFunc(bool isLowHealth)
    {
        LowHealthEvent?.Invoke(isLowHealth);
    }
}