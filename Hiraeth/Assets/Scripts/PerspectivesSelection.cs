using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//Cette classe sert a gerer la selection entre les deux perspectives.
public class PerspectivesSelection : MonoBehaviour
{
    public GameObject xrOrigin;
    public bool familiar = true;
    public bool inGame = false;
    public bool isPaused = true;
    public bool isStarted = false;
    [Header("Familiar")]
    public float familiarScale = 1;
    public GameObject familiarSpawnPoint;
    [Space]
    public GameObject familiarLeftHand;
    public GameObject familiarRightHand;
    [Space]
    [Header("Giant")]
    public float giantScale = 300;
    public GameObject giantSpawnPoint;
    [Space]
    public GameObject giantLeftHand;
    public GameObject giantRightHand;
    [Space]
    [Header("Menu")]
    public GameObject menuSpawnPoint;
    [Space]
    public GameObject wristMenu;
    public GameObject mainMenu;
    [Space]
    public GameObject leftHandRay;
    public GameObject rightHandRay;
    private float defaultRay;
    [Space]
    [Header("Avatars")]
    public GameObject menuHeadModel;
    public GameObject menuMouthMesh;
    public GameObject menuLeftHandModel;
    public GameObject menuRightHandModel;
    [Space]
    public GameObject familiarHeadModel;
    public GameObject familiarMouthMesh;
    public GameObject familiarLeftHandModel;
    public GameObject familiarRightHandModel;
    [Space]
    public GameObject giantHeadModel;
    public GameObject giantMouthMesh;
    public GameObject giantLeftHandModel;
    public GameObject giantRightHandModel;

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
        if (familiar && isPaused)
        {
            xrOrigin.transform.position = familiarSpawnPoint.transform.position;
            //xrOrigin.transform.rotation = familiarSpawnPoint.transform.rotation;
            xrOrigin.transform.localScale = new Vector3(familiarScale, familiarScale, familiarScale);

            mainMenu.SetActive(false);
            wristMenu.SetActive(false);
            inGame = true;
            isStarted = true;
            isPaused = false;

            leftHandRay.SetActive(false);
            rightHandRay.SetActive(false);
            familiarLeftHand.SetActive(true);
            familiarRightHand.SetActive(true);

            menuHeadModel.SetActive(false);
            menuMouthMesh.SetActive(false);
            menuLeftHandModel.SetActive(false);
            menuRightHandModel.SetActive(false);
            familiarHeadModel.SetActive(true);
            familiarMouthMesh.SetActive(true);
            familiarLeftHandModel.SetActive(true);
            familiarRightHandModel.SetActive(true);
}
        else if (familiar == false && isPaused)
        {
            if (isPaused && isStarted)
            {
                familiarSpawnPoint.transform.position = xrOrigin.transform.position;
            }

            xrOrigin.transform.position = giantSpawnPoint.transform.position;
            xrOrigin.transform.rotation = giantSpawnPoint.transform.rotation;
            xrOrigin.transform.localScale = new Vector3(giantScale, giantScale, giantScale);

            mainMenu.SetActive(false);
            wristMenu.SetActive(false);
            inGame = true;
            isStarted = true;
            isPaused = false;

            leftHandRay.SetActive(false);
            rightHandRay.SetActive(false);
            giantLeftHand.SetActive(true);
            giantRightHand.SetActive(true);

            menuHeadModel.SetActive(false);
            menuMouthMesh.SetActive(false);
            menuLeftHandModel.SetActive(false);
            menuRightHandModel.SetActive(false);
            giantHeadModel.SetActive(true);
            giantMouthMesh.SetActive(true);
            giantLeftHandModel.SetActive(true);
            giantRightHandModel.SetActive(true);
        }
        
    }

    public void PMainMenu()
    {
        if (inGame)
        {
            xrOrigin.transform.position = menuSpawnPoint.transform.position;
            xrOrigin.transform.rotation = menuSpawnPoint.transform.rotation;
            xrOrigin.transform.localScale = new Vector3(1, 1, 1);
            
            wristMenu.SetActive(false);
            mainMenu.SetActive(true);
            inGame = false;

            leftHandRay.SetActive(true);
            rightHandRay.SetActive(true);
            familiarLeftHand.SetActive(false);
            familiarRightHand.SetActive(false);           
            giantLeftHand.SetActive(false);
            giantRightHand.SetActive(false);

            menuHeadModel.SetActive(true);
            menuMouthMesh.SetActive(true);
            menuLeftHandModel.SetActive(true);
            menuRightHandModel.SetActive(true);
            familiarHeadModel.SetActive(false);
            familiarMouthMesh.SetActive(false);
            familiarLeftHandModel.SetActive(false);
            familiarRightHandModel.SetActive(false);
            giantHeadModel.SetActive(false);
            giantMouthMesh.SetActive(false);
            giantLeftHandModel.SetActive(false);
            giantRightHandModel.SetActive(false);
        }
    }

    public void wristActivate()
    {
        if (wristMenu.activeSelf)
        {
            wristMenu.SetActive(false);
            isPaused = false;

            leftHandRay.SetActive(false);
            rightHandRay.SetActive(false);
        }
        else if (wristMenu.activeSelf == false && mainMenu.activeSelf == false)
        {
            wristMenu.SetActive(true);
            isPaused = true;

            leftHandRay.SetActive(true);
            rightHandRay.SetActive(true);
        }
    }

    public void menuActivate()
    {
        if (mainMenu.activeSelf)
        {
            mainMenu.SetActive(false);
            isPaused = false;

            leftHandRay.SetActive(false);
            rightHandRay.SetActive(false);
        }
        else if (mainMenu.activeSelf == false)
        {
            mainMenu.SetActive(true);
            isPaused = true;

            leftHandRay.SetActive(true);
            rightHandRay.SetActive(true);
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
