using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Normal.Realtime;

//Cette classe sert a gerer la selection entre les perspectives.
public class PerspectivesSelection : MonoBehaviour
{
    //Declaration des variables de jeu
    public GameObject xrOrigin;
    public GameObject MainCamera;

    public AvatarManager avatarManager;

    public bool isFamiliar = true;
    public bool isGiant = false;

    public bool inGame = false;
    public bool isPaused = true;
    public bool isStarted = false;

    //Declaraiton des variables des avatars
    [Header("Familiar")]
    public float familiarScale = 1;
    public GameObject familiarSpawnPoint;
    [Space]
    public GameObject familiarLeftHand;
    public GameObject familiarRightHand;
    [Space]
    [Header("Giant")]
    public float giantScale = 300;
    public float giantHeight;
    public GameObject giantSpawnPoint;
    [Space]
    public GameObject giantLeftHand;
    public GameObject giantRightHand;
    [Space]
    public GameObject[] giantIndices;

    [Space]
    [Header("Cutscene")]
    public GameObject cutSceneSpawnPoint;
    [Space]
    [Header("Menu")]
    public GameObject menuSpawnPoint;
    [Space]
    public GameObject leftHandRay;
    public GameObject rightHandRay;    
    [Space]
    public GameObject wristMenu;
    public GameObject mainMenu;
    
    
    //Selection du familier
    public void PFamiliar()
    {
        isFamiliar = true;
        isGiant = false;
    }

    //Selection de la geante
    public void PGiant()
    {
        isFamiliar = false;
        isGiant = true;
    }

    //
    //Cette fonction repositionnement du joueur par rapport a la selection
    public void PConnect()
    {
        //Si le joueur a choisi le familier
        if (isFamiliar && isPaused)
        {
            //Repositionne le joueur au spawn point du familier mais pas en rotation
            xrOrigin.transform.position = familiarSpawnPoint.transform.position;
            //xrOrigin.transform.rotation = familiarSpawnPoint.transform.rotation;
            xrOrigin.transform.localScale = new Vector3(familiarScale, familiarScale, familiarScale);

            //Desactive les menus et annonce que la partie est commencer
            mainMenu.SetActive(false);
            wristMenu.SetActive(false);
            inGame = true;
            isStarted = true;
            isPaused = false;

            //Desactive et reactive les controles menu, familier et geante (+indices)
            leftHandRay.SetActive(false);
            rightHandRay.SetActive(false);

            familiarLeftHand.SetActive(true);
            familiarRightHand.SetActive(true);

            giantLeftHand.SetActive(false);
            giantRightHand.SetActive(false);

            foreach (GameObject light in giantIndices)
            {
                light.SetActive(false);
            }

            //Switch l'avatar
            avatarManager.SwitchFamilier();                  
                       
        }

        else if (isFamiliar == false && isPaused)
        {
            //Repositionne le joueur au spawn point du geant
            xrOrigin.transform.position = giantSpawnPoint.transform.position; 
            xrOrigin.transform.rotation = giantSpawnPoint.transform.rotation;
            xrOrigin.transform.localScale = new Vector3(giantScale, giantScale, giantScale);

            //Recentre le joueur par rapport a la position de sa tete
            xrOrigin.transform.position -= new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y - giantHeight, MainCamera.transform.position.z);
            float rotationAngleY = xrOrigin.transform.rotation.eulerAngles.y - giantSpawnPoint.transform.rotation.eulerAngles.y;
            xrOrigin.transform.Rotate(0, -rotationAngleY, 0);

            //Desactive les menus et annonce que la partie est commencer
            mainMenu.SetActive(false);
            wristMenu.SetActive(false);
            inGame = true;
            isStarted = true;
            isPaused = false;

            //Desactive et reactive les controles menu, familier et geante (+indices)
            leftHandRay.SetActive(false);
            rightHandRay.SetActive(false);

            familiarLeftHand.SetActive(false);
            familiarRightHand.SetActive(false);

            giantLeftHand.SetActive(true);
            giantRightHand.SetActive(true);

            foreach (GameObject light in giantIndices)
            {
                light.SetActive(true);
            }

            //Switch l'avatar
            avatarManager.SwitchGiant();
                        
        }
    }

    //Cette fonction repositionne le joueur au menu principale
    public void PMainMenu()
    {
        if (inGame)
        {
            //Repositionne le joueur au spawn point du menu
            xrOrigin.transform.position = menuSpawnPoint.transform.position;
            xrOrigin.transform.rotation = menuSpawnPoint.transform.rotation;
            xrOrigin.transform.localScale = new Vector3(1, 1, 1);

            //Desactive les menus et annonce que la partie est commencer
            wristMenu.SetActive(false);
            mainMenu.SetActive(true);
            inGame = false;

            //Desactive et reactive les controles menu, familier et geante (+indices)
            leftHandRay.SetActive(true);
            rightHandRay.SetActive(true);

            familiarLeftHand.SetActive(false);
            familiarRightHand.SetActive(false);  
            
            giantLeftHand.SetActive(false);
            giantRightHand.SetActive(false);

            foreach (GameObject light in giantIndices)
            {
                light.SetActive(false);
            }

            //Switch l'avatar
            avatarManager.SwitchMenu();

        }
    }

    //Cette fonction repositionne le joueur dans la cutscene
    public void PCutscene()
    {
        //Repositionne le joueur au spawn point de la cutscene
        xrOrigin.transform.position = cutSceneSpawnPoint.transform.position;
        xrOrigin.transform.rotation = cutSceneSpawnPoint.transform.rotation;
        xrOrigin.transform.localScale = Vector3.one;

        //Desactive les menus et annonce que la partie est commencer
        //mainMenu.SetActive(false);
        //wristMenu.SetActive(false);
        inGame = true;
        isStarted = true;
        isPaused = false;

        //Desactive les controles menu, familier et geante
        leftHandRay.SetActive(false);
        rightHandRay.SetActive(false);

        familiarLeftHand.SetActive(false);
        familiarRightHand.SetActive(false);

        giantLeftHand.SetActive(false);
        giantRightHand.SetActive(false);

        //Switch l'avatar
        //avatarManager.SwitchCutscene();
    }

    //
    //Active ou desactive le menu au poignet
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

    //Active ou desactive le menu principale
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

    //
    //Si le joueur est un familier, cette fonction repositionne le spawn point ou il est
    public void SetFamiliarSpawn()
    {
        if (isFamiliar)
        {
            familiarSpawnPoint.transform.position = xrOrigin.transform.position;
        }
    }  
}
