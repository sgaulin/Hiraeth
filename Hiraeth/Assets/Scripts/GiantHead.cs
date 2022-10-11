using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHead : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GiantHead"))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(true);
    }
}
