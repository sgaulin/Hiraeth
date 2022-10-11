using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCount : MonoBehaviour
{
    public int count = 0;
    public int total = 1;

    public List<GameObject> activateFX;


    public void incrementCrystal()
    {
        count++;
    }

    public void decrementCrystal()
    {
        count--;
    }

    public void activationCrystal()
    {
        if (count >= total)
        {
            foreach (var item in activateFX)
            {
                item.SetActive(true);
            }
        }
    }

}
