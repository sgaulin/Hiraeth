using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    //public Rigidbody rb;

    public float speed = 1.0f;
    public Vector3 direction = new Vector3(1,0,0);     

    void Start()
    {
        //rb = GetComponent<Rigidbody>();            
    }
 
    private void FixedUpdate()
    {
        //rb.AddForce(direction * speed);
        transform.position += direction * speed;
    }
}