using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameField;

    private void Start()
    {
        UIEventController.Instance.NameUpdate += SetName;
    }

    private void SetName(string name)
    {
        nameField.text = name;
    }
}
