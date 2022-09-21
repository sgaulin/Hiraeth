using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//Cette classe sert a gerer la selection entre les deux perspectives.
public class PSelect : MonoBehaviour
{
    public GameObject xrOrigin;
    public bool familiar = true;
    public bool inGame = false;
    [Header("Familiar")]
    public float familiarScale = 1;
    public GameObject familiarSpawnPoint;
    [Space]
    public GameObject familiarHead;
    public GameObject familiarLeftHand;
    public GameObject familiarRightHand;
    [Space]
    [Header("Giant")]
    public float giantScale = 300;
    public GameObject giantSpawnPoint;
    [Space]
    public GameObject giantHead;
    public GameObject giantLeftHand;
    public GameObject giantRightHand;
    [Space]
    [Header("Menu/Interactors")]
    public GameObject menuSpawnPoint;
    [Space]
    public GameObject wristMenu;
    public GameObject mainMenu;
    [Space]
    public GameObject leftHandRay;
    public GameObject rightHandRay;
    private float defaultRay;

    private void Start()
    {
        defaultRay = rightHandRay.GetComponent<XRInteractorLineVisual>().lineWidth;
    }

    public void PFamiliar()
    {
        familiar = true;
    }

    public void PGiant()
    {
        familiar = false;
    }

    public void PConnect()
    {
        if (familiar && inGame == false )
        {
            xrOrigin.transform.position = familiarSpawnPoint.transform.position;
            xrOrigin.transform.rotation = familiarSpawnPoint.transform.rotation;
            xrOrigin.transform.localScale = new Vector3(familiarScale, familiarScale, familiarScale);

            mainMenu.SetActive(false);
            inGame = true;

            //familiarHead.SetActive(true);
            familiarLeftHand.SetActive(true);
            familiarRightHand.SetActive(true);
        }
        else if (familiar == false && inGame == false)
        {
            xrOrigin.transform.position = giantSpawnPoint.transform.position;
            xrOrigin.transform.rotation = giantSpawnPoint.transform.rotation;
            xrOrigin.transform.localScale = new Vector3(giantScale, giantScale, giantScale);

            rightHandRay.GetComponent<XRInteractorLineVisual>().lineWidth *= giantScale;
            mainMenu.SetActive(false);
            inGame = true;

            //giantHead.SetActive(true);
            giantLeftHand.SetActive(true);
            giantRightHand.SetActive(true);
        }
        
    }

    public void PMenu()
    {
        if (inGame)
        {
            xrOrigin.transform.position = menuSpawnPoint.transform.position;
            xrOrigin.transform.rotation = menuSpawnPoint.transform.rotation;
            xrOrigin.transform.localScale = new Vector3(1, 1, 1);

            rightHandRay.GetComponent <XRInteractorLineVisual>().lineWidth = defaultRay;
            wristMenu.SetActive(false);
            mainMenu.SetActive(true);
            inGame = false;

            //familiarHead.SetActive(false);
            familiarLeftHand.SetActive(false);
            familiarRightHand.SetActive(false);

            //giantHead.SetActive(false);
            giantLeftHand.SetActive(false);
            giantRightHand.SetActive(false);
        }
    }

    public void wristActivate()
    {
        if (wristMenu.activeSelf)
        {
            wristMenu.SetActive(false);
        }
        else if (wristMenu.activeSelf == false)
        {
            wristMenu.SetActive(true);
        }
    }
    // Lorqu'il y a une collision, si le tag de l'object avec lequel on est entre en collision est nomme Head
    // Si le scale de la racine de l'objet est plus petit que 10, on scale up
    // Si le scale de la racine de l'objet est plus grand que 10, on scale down

    //public float threshold = 10;

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.tag == "MainCamera")
    //    {
    //        if (collision.transform.root.localScale.x < threshold)
    //        {
    //            collision.transform.parent.parent.localScale = new Vector3(giantScale, giantScale, giantScale);
    //            Destroy(gameObject);
    //        }

    //        else if (collision.transform.root.localScale.x > threshold)
    //        {
    //            collision.transform.parent.parent.localScale = new Vector3(familiarScale, familiarScale, familiarScale);
    //            Destroy(gameObject);
    //        }
    //    }        
    //}    
}
