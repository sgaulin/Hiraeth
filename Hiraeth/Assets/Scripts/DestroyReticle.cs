using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyReticle : MonoBehaviour
{

    public void Activate()
    {
        GameObject.Find("SM_FX_Glow_Ring_01(Clone)").SetActive(true);
    }
    public void DeActivate()
    {
        GameObject.Find("SM_FX_Glow_Ring_01(Clone)").SetActive(false);
    }
}
