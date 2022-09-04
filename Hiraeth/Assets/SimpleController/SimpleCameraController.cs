using UnityEngine;

// Cette classe sert à faire bouger la caméra pour suivre le joueur.
public class SimpleCameraController : MonoBehaviour
{
    // Creation d'un GameObject Public pour lui assigner le game object du joueur dans l'editeur.
    // Creation d'une variable pour stocker un vecteur d'offset pour placer la camera par rapport au joueur.
    public GameObject player;
    private Vector3 offset;

    // Creation de variables pour le controles de la camera avec l'input de la sourie
    // Credits au channel YouTube "Learn Everything Fast" pour la video "Rotate Camera with Mouse in Unity3D"
    public float speedHorizontale = 2;
    public float speedVerticale = 2;

    private float yaw = 0;
    private float pitch = 0;

    // Cette fonction soustrait la position du joueur par rapport à la caméra et stock la distance dans une variable.
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // À chaque frame, cette fonction repositionne la camera sur le joueur et lui ajoute une distance d'offset pour le cadrer.
    // Les variables de yaw de et pitch sont multiplier aux variables de vitesse et a l'input de la sourie,
    // et la rotation de la camera est repositionne a chaque frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        yaw += speedHorizontale * Input.GetAxis("Mouse X");
        pitch -= speedVerticale * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}
