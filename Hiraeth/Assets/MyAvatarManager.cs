using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAvatarManager : MonoBehaviour
{
    private RealtimeAvatarManager _manager;
    public GameObject FamilierAvatar;
    public GameObject GiantAvatar;
    public GameObject MenuAvatar;

    private void Awake()
    {
        _manager = GetComponent<RealtimeAvatarManager>();
    }

    public void SwitchFamilier()
    {
        _manager.localAvatarPrefab = FamilierAvatar;
    }

    public void SwitchGiant()
    {
        _manager.localAvatarPrefab = GiantAvatar;
    }
    public void SwitchMenu()
    {
        _manager.localAvatarPrefab = MenuAvatar;
    }
}
