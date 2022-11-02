using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabRequest : MonoBehaviour
{
    private RealtimeTransform realtimetransform;
    private XRGrabInteractable xrgrabinteractable;

    private GameObject fx;

    // Start is called before the first frame update
    void Start()
    {
        realtimetransform = GetComponent<RealtimeTransform>();
        xrgrabinteractable = GetComponent<XRGrabInteractable>();
        fx = this.transform.Find("--FX--").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(xrgrabinteractable.isSelected)
        {
            realtimetransform.RequestOwnership();
            fx.SetActive(true);
        }
    }
}
