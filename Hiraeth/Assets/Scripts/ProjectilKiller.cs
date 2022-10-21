using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        Destroy(other.gameObject);
    }
}
