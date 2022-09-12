using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cette classe sert a gerer les interactions avec le champignon
public class Shroom : MonoBehaviour
{
    // Declaration de variables public pour scaler up et down le joueur
    public float giantScale = 300;
    public float familiarScale = 1;
    public float threshold = 10;

    // Lorqu'il y a une collision, si le tag de l'object avec lequel on est entre en collision est nomme Head
    // Si le scale de la racine de l'objet est plus petit que 10, on scale up
    // Si le scale de la racine de l'objet est plus grand que 10, on scale down
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "MainCamera")
        {
            if (collision.transform.root.localScale.x < threshold)
            {
                collision.transform.parent.parent.localScale = new Vector3(giantScale, giantScale, giantScale);
                Destroy(gameObject);
            }

            else if (collision.transform.root.localScale.x > threshold)
            {
                collision.transform.parent.parent.localScale = new Vector3(familiarScale, familiarScale, familiarScale);
                Destroy(gameObject);
            }
        }

        
    }

    
}
