using UnityEngine;
using UnityEngine.InputSystem;

public class movement_player : MonoBehaviour
{
    //variable utiliser pour le d�placement du personnage
    [SerializeField]  float player_speed;
    [SerializeField] float sprint_speed;
    [SerializeField] CharacterController controller;


    //variable utiliser pour le mouvemen de la cam�ra
    [SerializeField] float speed_cam;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
    float xRotation = 0;


    //variable pour  la graviter 
    float gravity = -9.81f;
    float velocity;
    Vector3 gravity_force;


    //variable pour le sauts du personnage
    [SerializeField] float jump_force;
    Vector3 jump;
   


    // fonction pour pouvoir d�placer le joueur 
    void movement()
    {
        float movement_x = Input.GetAxis("Horizontal");
        float movement_y = Input.GetAxis("Vertical");
        Vector3 player_movement = transform.right * movement_x * Time.deltaTime * player_speed + transform.forward * movement_y * Time.deltaTime * player_speed;
        controller.Move(player_movement);
    }
    //fonction pour le sprint 
    void apply_sprint()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            Vector3 player_sprint = transform.forward * Time.deltaTime * sprint_speed;
            controller.Move(player_sprint);
        }
    }
    //fonction pour le saut 
    void apply_jump()
    {
        
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {

            jump.y = jump_force;
            
        }
        controller.Move(jump * Time.deltaTime);
        jump.y += velocity * Time.deltaTime;
       

    }
    
    //fonction pour d�placer la cam�ra
    void cam_movement()
    {
        float cam_x = Input.GetAxis("Mouse X");
        float cam_y = Input.GetAxis("Mouse Y");
        Vector3 cam_position_y = new Vector3(0, cam_x, 0) * speed_cam * Time.deltaTime;
        xRotation -= cam_y;
        player.transform.Rotate( cam_position_y);
        xRotation = Mathf.Clamp(xRotation, -70f, 70f); // limite haut/bas
        cam.transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
    }

    //fonction pour la graviter du joueur 
    void apply_gravity()
    {
        velocity += gravity * Time.deltaTime;
        gravity_force.y = velocity;
        controller.Move(gravity_force * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocity = -2f; 
        }
    }


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        movement();
        cam_movement();
        apply_gravity();
        apply_sprint();
        apply_jump();
    }
}
