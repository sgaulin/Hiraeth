using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    [Header("Collision")]
    private AudioSource hitSound;
    public float velocityThreshold = 1;
    public float repeatPercent = 1;
    [Space]
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    [Header("Sploush")]
    public GameObject sploushFX;
    public float destroyDelay = 5.0f;

    private float nextSoundTime = 0;


    private void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("Collision sound with " + this.name + " and " + collision.gameObject.name);

        if (collision.relativeVelocity.magnitude >= velocityThreshold)
        {
            if (Time.time>=nextSoundTime)
            {
                if(this.tag != collision.collider.tag && collision.collider.tag != "Water")
                {
                    hitSound.pitch = Random.Range(minPitch, maxPitch);
                    hitSound.Play();
                    nextSoundTime = Time.time + ( hitSound.clip.length * repeatPercent );
                }				
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time >= nextSoundTime)
        {
            if (this.tag == "Water" && (other.tag == "Rocks" || other.tag == "Tree" || other.tag == "Crystal" ))
            {
                Debug.Log("splash" + other.gameObject.name);                
                nextSoundTime = Time.time + (sploushFX.GetComponentInChildren<AudioSource>().clip.length * repeatPercent);
                GameObject sploush = (GameObject)Instantiate(sploushFX, other.transform.position, Quaternion.identity);
                sploush.GetComponentInChildren<AudioSource>().pitch = Random.Range(minPitch, maxPitch);
                Destroy(sploush, destroyDelay);                
            }
        }
    }
}
