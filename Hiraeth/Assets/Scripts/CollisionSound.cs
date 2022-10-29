using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private bool canPlay = true;
    public float delay = 0.3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (canPlay)
        {
            canPlay = false;
            GetComponent<AudioSource>().Play();
        }

    }
}
