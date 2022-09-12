using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    private float defaultIntensity = 1;

    private void Start()
    {
        defaultIntensity = RenderSettings.ambientIntensity;
    }

    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.ambientIntensity = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        RenderSettings.ambientIntensity = defaultIntensity;

    }

}

