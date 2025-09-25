using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader
{
    protected string resourceDataLocation = string.Empty;
    protected TextAsset jsonFile;

    protected const string JSON_LOAD_ERROR = "WTF JSON";

    public DataLoader()
    {

    }
    protected virtual void LoadJSONData()
    {
        jsonFile = Resources.Load<TextAsset>(resourceDataLocation);
        if (jsonFile == null)
        {
            Debug.LogError(JSON_LOAD_ERROR);
            return;
        }
    }

    public virtual object GetPrefabFromID(int id)
    {
        if (!TnS_GlobalSettings.RELEASE_VERSION)
        {
            Debug.Log("Loading from " + resourceDataLocation + " with ID: " + id);
        }
        return null;
    }
}
