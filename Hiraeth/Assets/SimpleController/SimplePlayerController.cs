using UnityEngine;
using UnityEngine.InputSystem;

// Cette classe sert a deplacer le joueur avec les inputs clavier du joueur
public class SimplePlayerController : MonoBehaviour
{
    // Initiation d'une variable publique pour stocker la vitesse de deplacement du joueur.
    // Creation d'une variable pour stocker le rigidbody du joueur
    // Creation de deux variables pour stocker le vecteur de l'input clavier du joueur.
    public float speed = 100;  
    private Rigidbody rb;    
    private float movementX;
    private float movementY;

    // Creation des variables pour que les controles suivent l'orientation de la camera
    // Credit a Gabriel Laliberte
    private GameObject cam;
    private Vector3 camForward;
    private Vector3 camRight;


    // Cette methode stock le rigidbody du joueur dans une variable,
    // et elle cherche la camera active FPS ou TPS.
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        cam = GameObject.Find("FPSCamera");
        if(cam == null)
        {
            cam = GameObject.Find("TPSCamera");
        }

    }

    // A chaque frame fix, cette methode ajoute un force sur le joueur pour le deplacer,
    // en fonction du vecteur de son input clavier et de la vitesse.
    // Mise a jour des vecteur de la camera
    // et les multiplie aux vecteur des movement pour suivre l'orientaiton de la camera
    private void FixedUpdate()
    {
        camForward = cam.transform.forward;
        camRight = cam.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;

        //Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        Vector3 movement = (camForward * movementY + camRight * movementX);
        rb.AddForce(movement * speed);       
        
    }

    // Cette methode stock l'input clavier du joueur dans une variable de type vecteur 2 et elle assigne chacune des valeurs a une variable.
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }      
        
}
