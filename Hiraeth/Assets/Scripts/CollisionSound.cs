using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioSource hitSound;
    public float velocityThreshold = 1;

    public GameObject sploushFX;
    public float destroyDelay = 5.0f;
	
	//private float randomValue = 0;

    private void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude >= velocityThreshold)
        {
            if (!hitSound.isPlaying)
            {
				//random;
                hitSound.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.tag == "Water")
        {
            GameObject sploush = (GameObject)Instantiate(sploushFX, other.transform.position, Quaternion.identity);
            Destroy(sploush, destroyDelay);
        }
    }
}
