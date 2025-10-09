using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
//ce sript utilise weapon instantiate
public class weapon_attaque : MonoBehaviour
{
    //variable pour le raycast
    RaycastHit hit;
    [SerializeField] weaponinstantiate weapons_created;
    [SerializeField] weaponinstantiate hand_left;
    [SerializeField] weaponinstantiate hand_right;
    [SerializeField] GameObject cam;
   public int weapon_diff;
    bool right_hand;
    bool left_hand;



    //variable pour la sphère cast
    Collider[] enemies;

   

    //dégat pour les différente arme
    float hand_dommage;
    float axe_dommage;
    float sickle_dommage;
    float pitchfork_dommage;
    int rarety;
    float double_hand_dammage = 1.5f;

    //PV du zombie
    [SerializeField] pv_zombie zombie;

    //fonction pour savoir quelle arme le joueur a en main
    void What_weapon()
    {
        
        weapon_diff = weapons_created.GetComponent<weaponinstantiate>().weapon_diff;
        right_hand = hand_right.right_hand;
        left_hand = hand_left.left_hand;

        if (weapon_diff == 0 && right_hand == false ) //le 0 signifie main nue
        {
            Debug.DrawRay(transform.position, cam.transform.forward * 2, Color.red);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(transform.position, cam.transform.forward, out hit, 4))
                {

                    
                    if (hit.transform.GetComponent<pv_zombie>())
                    {
                        hand_dommage = 2;
                        hit.transform.GetComponent<pv_zombie>().nb_pv_zombie -= hand_dommage;
                    }
   

                }
            }

        }
        
        if (weapon_diff == 1) //le 1 signfie la hache
        {
            //raycast en boule pour toucher plus d'enemie
            //il faut faire la hache
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                enemies = Physics.OverlapSphere(cam.transform.position + cam.transform.forward * 2f, 2);
                foreach (Collider col in enemies)
                {
                    if (col.transform.GetComponent<pv_zombie>())
                    {
                        axe_dommage = rarety * (double_hand_dammage * 7);
                        col.transform.GetComponent<pv_zombie>().nb_pv_zombie -= axe_dommage;
                    }
                }

            }


        }
        if (weapon_diff == 2) //le 2 signifie la faussile
        {
            Debug.DrawRay(transform.position, cam.transform.forward * 2, Color.red);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(transform.position, cam.transform.forward, out hit, 4))
                {
                    if (hit.transform.GetComponent<pv_zombie>())
                    {
                        sickle_dommage = rarety * (double_hand_dammage * 5);
                        hit.transform.GetComponent<pv_zombie>().nb_pv_zombie -= sickle_dommage;
                    }
               
                }
            }
        }
        if (weapon_diff == 3)// le 3 signifie la fouche
        {
            Debug.DrawRay(transform.position, cam.transform.forward * 4, Color.red);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(transform.position, cam.transform.forward, out hit, 4))//creation d'un raycast
                {
                    if (hit.transform.GetComponent<pv_zombie>())//verification que le gameobject possède le script pv_zombie
                    {

                        pitchfork_dommage = rarety * (double_hand_dammage * 8);
                        hit.transform.GetComponent<pv_zombie>().nb_pv_zombie  -= pitchfork_dommage;

                       

                    }
             
                }
            }
            
        }
    }

    //fonction pour savoir si les deux main sont utiliser pour le combat 
    void Double_hand_active()
    {
        right_hand = hand_right.right_hand;
        left_hand = hand_left.left_hand;
        if (right_hand == true && left_hand == false)
        {
            double_hand_dammage = 1;
        }
        else if (right_hand == true && left_hand == true)
        {
            double_hand_dammage = 1.5f;
        }
        else if (right_hand == false && left_hand == false)
        {
            double_hand_dammage = 1;
        }
        else if (right_hand == false && left_hand == true)
        {
            double_hand_dammage = 1;
        }

    }

    private void OnDrawGizmos()
    {
        if (weapon_diff == 1) //le 1 signfie la hache
        {

           Gizmos.DrawSphere(cam.transform.position + cam.transform.forward * 2f, 2);

        }
    }


    //fonction pour créer et voir un raycast
    void Weapon_collision_detected()
    {
        
   

    }
    private void Start()
    {
        rarety = 1;
        
    }


    private void Update()
    {
        Weapon_collision_detected();
        What_weapon();
        Double_hand_active();
     
    }
}
