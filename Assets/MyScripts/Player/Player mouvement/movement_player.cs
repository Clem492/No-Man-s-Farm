using UnityEngine;
using UnityEngine.InputSystem;

public class movement_player : MonoBehaviour
{
    //variable utiliser pour le déplacement du personnage
    [SerializeField]  float player_speed;
    [SerializeField] float sprint_speed;
    [SerializeField] CharacterController controller;
    [SerializeField] AudioSource son_pas;

    //variable utiliser pour le mouvemen de la caméra
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

    //variable pour le tuto
    public int tutorial_move;
    bool can_move_forward;
    bool can_move_right;
    float movement_y;
    float movement_x;
    public bool tutorial_cam;
    float cam_x;
    float cam_y;
    // fonction pour pouvoir déplacer le joueur 
    void movement()
    {
        if (tutorial_move == 1)
        {
            movement_y = Input.GetAxis("Vertical");
            can_move_forward = true;
            Debug.Log("entrer");
        }
        if (tutorial_move ==2)
        {
            movement_x = Input.GetAxis("Horizontal");
            can_move_right = true;
        }
        if (can_move_forward)
        {
            movement_y = Input.GetAxis("Vertical");
        }
        if (can_move_right)
        {
            movement_x = Input.GetAxis("Horizontal");
        }
        if(movement_x !=0 || movement_y != 0)
        {
            son_pas.Play();
        }
        if(movement_x == 0 && movement_y == 0)
        {
            son_pas.Stop();
        }
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
    
    //fonction pour déplacer la caméra
    void cam_movement()
    {
        if (tutorial_cam)
        {
            cam_x = Input.GetAxis("Mouse X");
            cam_y = Input.GetAxis("Mouse Y");
        }
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
        tutorial_move = 0;
        can_move_forward = false;
        can_move_right = false;
        tutorial_cam = false;
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
