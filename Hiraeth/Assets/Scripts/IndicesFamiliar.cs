using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicesFamiliar : MonoBehaviour
{
    //Lorsque qu'un object entre en collision avec le trigger
    //si il est tagger comme familiar, le mesh renderer devient visible
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Familiar")
        {           
            foreach (MeshRenderer render in GetComponentsInChildren<MeshRenderer>())
            {
                render.enabled = true;
            }
        }
    }

    //Lorsque qu'un object sors de la collision avec le trigger
    //si il est tagger comme familiar, le mesh renderer devient invisible
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Familiar")
        {
            foreach (MeshRenderer render in GetComponentsInChildren<MeshRenderer>())
            {
                render.enabled = false;
            }
        }
    }
}
