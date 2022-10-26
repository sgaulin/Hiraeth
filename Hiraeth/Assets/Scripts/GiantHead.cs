using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GiantHead : MonoBehaviour
{
    private void FixedUpdate()
    {
        gameObject.transform.position = GameObject.FindGameObjectWithTag("GiantHead").transform.position;
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    //if (other.gameObject.CompareTag("GiantHead"))
    //    //{
    //        other.gameObject.GetComponent<RealtimeTransform>().RequestOwnership();
    //        other.gameObject.GetComponent<Renderer>().enabled = false;
    //    //}
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    other.gameObject.GetComponent<RealtimeTransform>().RequestOwnership();
    //    other.gameObject.SetActive(true);
    //}
}
