using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class movement_player : MonoBehaviour
{
    //variable utiliser pour le déplacement du personnage
    [SerializeField]  float player_speed;
    [SerializeField] float sprint_speed;
    [SerializeField] CharacterController controller;
    [SerializeField] GameObject menu_pause;
    [SerializeField] AudioSource son_pas;

    Vector3 player_movement;



    //variable utiliser pour le mouvemen de la caméra
    [SerializeField] float speed_cam;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
   public float xRotation = 0;


    //variable pour  la graviter 
    float gravity = -9.81f;
    float velocity;
    Vector3 gravity_force;


    //variable pour le sauts du personnage
    [SerializeField] float jump_force;
    Vector3 jump;

    //variable pour le tuto
    public int tutorial_move;
   public bool can_move_forward;
   public bool can_move_right;
   public float movement_y;
   public float movement_x;
    public bool tutorial_cam;
   public float cam_x;
   public float cam_y;

    //récupération du canva de la table de craft pour bloquer les mouvement de caméras du joueur 
    [SerializeField] craft_inventory craft_Inventory;

    //recuperer le slider pour le temp qu'il reste en sprint
    [SerializeField] Slider sprint_slider;
    //déclaration du temp que dure le sprint 
    
    [SerializeField] float sprint_time;
    
    //déclaration d'un booléen pour savoir si le joueur sprint ou non
    public bool can_sprint;
    public bool rechargement_sprint;
    // fonction pour pouvoir déplacer le joueur 
    void movement()
    {
        if(menu_pause.GetComponent<script_pause>().ecran_pause_actif == false)
        {
            movement_y = Input.GetAxis("Vertical");
            movement_x = Input.GetAxis("Horizontal");
            if (controller.velocity.y != 0)
            {
                son_pas.enabled = true;
            }
            
            else
            {
                son_pas.enabled = false;
            }

            Vector3 player_movement = transform.right * movement_x * Time.deltaTime * player_speed + transform.forward * movement_y * Time.deltaTime * player_speed;



            player_movement = transform.right * movement_x * Time.deltaTime * player_speed + transform.forward * movement_y * Time.deltaTime * player_speed;

            controller.Move(player_movement);
        }
        else
        {
            son_pas.enabled = false;
        }
        
        
    }
    //fonction pour le sprint 
    void apply_sprint()
    {

        if (can_sprint)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                sprint_slider.gameObject.SetActive(true);
                sprint_slider.value -= Time.deltaTime;
                Vector3 player_sprint = transform.forward * Time.deltaTime * sprint_speed;
                controller.Move(player_sprint);
            }
            else if (!Input.GetKeyUp(KeyCode.LeftShift) && sprint_slider.value < sprint_slider.maxValue && can_sprint)
            {
                
                can_sprint = false;
                rechargement_sprint = true;
            }
        }
        if (sprint_slider.value <= 0)
        {
            
            can_sprint = false;
            rechargement_sprint = true;
            
            
        }
        if (rechargement_sprint)
        {
            sprint_slider.value += Time.deltaTime;
            if (sprint_slider.value == sprint_time)
            {
                can_sprint = true;
                rechargement_sprint = false;
                sprint_slider.gameObject.SetActive(false);
            }
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

        if (craft_Inventory.craft_canva.enabled == false)
        {
            if (menu_pause.GetComponent<script_pause>().ecran_pause_actif == false)
            {
                cam_x = Input.GetAxis("Mouse X");
                cam_y = Input.GetAxis("Mouse Y");
            }
            else
            {
                cam_x = 0;
                cam_y = 0;
            }

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
        can_sprint = true;
        sprint_slider.gameObject.SetActive(false);
        sprint_slider.maxValue = sprint_time;
        sprint_slider.value = sprint_time;
    }

    private void Update()
    {
        movement();
        cam_movement();
        apply_gravity();
        apply_jump();
        apply_sprint();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //}
        
    }
    
}
