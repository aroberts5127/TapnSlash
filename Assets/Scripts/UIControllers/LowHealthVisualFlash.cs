using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class LowHealthVisualFlash : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume ppv;
    Vignette v;

    [SerializeField]
    private Color lowHealthColor = Color.red;

    private bool isLowHealth;

    private void Start()
    {
        if(ppv == null)
        {
            Destroy(this);
        }
        UIEventController.Instance.LowHealthEvent += StartLowHealthFunc;
        ppv.profile.TryGetSettings<Vignette>(out v);
    }

    private void StartLowHealthFunc(bool ilh)
    {
        isLowHealth = ilh;
        StartCoroutine(HealthLowFlashCycle());
    }


    private IEnumerator HealthLowFlashCycle()
    {
        if (v == null)
        {
            Debug.LogError("WTF");
            yield break;
        }
        Color startColor = v.color.value;
        while (isLowHealth)
        {
            Debug.Log("Inside Coroutine Loop");
            //Color.Lerp(startColor, lowHealthColor, Time.deltaTime);
            v.color.value = lowHealthColor;
            yield return new WaitForSeconds(1.0f); //TODO - LERP BETWEEN THESE VALUES
            v.color.value = startColor;
            yield return new WaitForSeconds(1.0f);
            //Color.Lerp(lowHealthColor, startColor, Time.deltaTime);
        }
        v.color.value = startColor;
    }
}
