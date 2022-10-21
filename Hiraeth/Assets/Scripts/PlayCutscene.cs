using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCutscene : MonoBehaviour
{
    //Cette fonction demarre l'animation place dans chacun des enfants
    public void PlayAnimation()
    {
        foreach (Animation animation in GetComponentsInChildren<Animation>())
        {
            animation.Play();
        }
    }

    public void PlayMusic()
    {
        GetComponent<AudioSource>().Play();
    }
}
