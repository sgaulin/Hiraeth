using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    private RealtimeAvatarManager _manager;
    public GameObject FamilierAvatar;
    public GameObject GiantAvatar;
    public GameObject MenuAvatar;

    //[Header("Avatars")]
    //public GameObject menuHeadModel;
    //public GameObject menuMouthMesh;
    //public GameObject menuLeftHandModel;
    //public GameObject menuRightHandModel;
    //[Space]
    //public GameObject familiarHeadModel;
    //public GameObject familiarMouthMesh;
    //public GameObject familiarLeftHandModel;
    //public GameObject familiarRightHandModel;
    //[Space]
    //public GameObject giantHeadModel;
    //public GameObject giantMouthMesh;
    //public GameObject giantLeftHandModel;
    //public GameObject giantRightHandModel;

    private void Awake()
    {
        _manager = GetComponent<RealtimeAvatarManager>();
    }

    public void SwitchFamilier()
    {
        _manager.localAvatarPrefab = FamilierAvatar;

        //if (GetComponent<RealtimeView>().isOwnedLocallySelf)
        //{
        //    menuHeadModel.SetActive(false);
        //    menuMouthMesh.SetActive(false);
        //    menuLeftHandModel.SetActive(false);
        //    menuRightHandModel.SetActive(false);
        //    familiarHeadModel.SetActive(true);
        //    familiarMouthMesh.SetActive(true);
        //    familiarLeftHandModel.SetActive(true);
        //    familiarRightHandModel.SetActive(true);
        //    giantHeadModel.SetActive(false);
        //    giantMouthMesh.SetActive(false);
        //    giantLeftHandModel.SetActive(false);
        //    giantRightHandModel.SetActive(false);
        //}
    }

    public void SwitchGiant()
    {
        _manager.localAvatarPrefab = GiantAvatar;

        //if (GetComponent<RealtimeView>().isOwnedLocallySelf)
        //{

        //    menuHeadModel.SetActive(false);
        //    menuMouthMesh.SetActive(false);
        //    menuLeftHandModel.SetActive(false);
        //    menuRightHandModel.SetActive(false);
        //    familiarHeadModel.SetActive(false);
        //    familiarMouthMesh.SetActive(false);
        //    familiarLeftHandModel.SetActive(false);
        //    familiarRightHandModel.SetActive(false);
        //    giantHeadModel.SetActive(true);
        //    giantMouthMesh.SetActive(true);
        //    giantLeftHandModel.SetActive(true);
        //    giantRightHandModel.SetActive(true);
        //}
    }
    public void SwitchMenu()
    {
        _manager.localAvatarPrefab = MenuAvatar;

        //if (GetComponent<RealtimeView>().isOwnedLocallySelf)
        //{
        //    menuHeadModel.SetActive(true);
        //    menuMouthMesh.SetActive(true);
        //    menuLeftHandModel.SetActive(true);
        //    menuRightHandModel.SetActive(true);
        //    familiarHeadModel.SetActive(false);
        //    familiarMouthMesh.SetActive(false);
        //    familiarLeftHandModel.SetActive(false);
        //    familiarRightHandModel.SetActive(false);
        //    giantHeadModel.SetActive(false);
        //    giantMouthMesh.SetActive(false);
        //    giantLeftHandModel.SetActive(false);
        //    giantRightHandModel.SetActive(false);
        //}
    }
}
