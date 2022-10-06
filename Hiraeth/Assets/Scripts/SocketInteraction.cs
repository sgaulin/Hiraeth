using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class SocketInteraction : MonoBehaviour
{
    private void onSelectEnter (XRBaseInteractable interactable)
    {
        interactable.gameObject.SetActive (false); 
    }
}
