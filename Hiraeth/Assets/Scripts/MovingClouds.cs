using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    public bool Animated = true;

    public float speed = 1.0f;
    public Vector3 direction = new Vector3(1,0,0);  
    
    public Vector3 reset = new Vector3(0,0,0);
        
 
    private void FixedUpdate()
    {
        if (Animated)
        {
            transform.position += direction * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position += reset;
    }
}