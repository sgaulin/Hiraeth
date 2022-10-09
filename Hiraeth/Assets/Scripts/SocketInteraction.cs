using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class SocketInteraction : MonoBehaviour
{
    XRSocketInteractor socket;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    public void Chop()
    {
        IXRSelectInteractable obj = socket.interactablesSelected[0];
        obj.transform.gameObject.SetActive(false);
        socket.allowSelect = false;
        socket.allowHover = false;
    }
}
