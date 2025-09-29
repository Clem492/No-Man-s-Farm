using UnityEngine;
using UnityEngine.InputSystem;

public class movement_player : MonoBehaviour
{
    //variable utiliser pour le déplacement du personnage
    [SerializeField]  float player_speed;
    [SerializeField] CharacterController controller;
    //variable utiliser pour le mouvemen de la caméra
    [SerializeField] float speed_cam;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
    float xRotation = 0;



    // fonction pour pouvoir déplacer le joueur 
    void movement()
    {
        float movement_x = Input.GetAxis("Horizontal");
        float movement_y = Input.GetAxis("Vertical");
        Vector3 player_movement = transform.right * movement_x * Time.deltaTime * player_speed + transform.forward * movement_y * Time.deltaTime * player_speed;
        controller.Move(player_movement);
    }
    //fonction pour déplacer la caméra
    void cam_movement()
    {
        float cam_x = Input.GetAxis("Mouse X");
        float cam_y = Input.GetAxis("Mouse Y");
        Vector3 cam_position_x = new Vector3(0, cam_x, 0) * speed_cam * Time.deltaTime;
        xRotation -= cam_y;
        player.transform.Rotate( cam_position_x);
        xRotation = Mathf.Clamp(xRotation, -60f, 60f); // limite haut/bas
        cam.transform.rotation = Quaternion.Euler(xRotation,0f,0f);
      

    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        movement();
        cam_movement();
    }
}
