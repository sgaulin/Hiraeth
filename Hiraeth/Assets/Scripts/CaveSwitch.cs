using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cette classe sert a gerer les changements de rendu et d'eclairage lorsqu'on entre ou sors d'une grotte.
public class CaveSwitch : MonoBehaviour
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

