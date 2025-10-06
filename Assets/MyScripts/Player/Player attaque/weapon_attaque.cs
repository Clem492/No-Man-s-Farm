using Unity.VisualScripting;
using UnityEngine;

public class weapon_attaque : MonoBehaviour
{
    //variable pour le raycast
    RaycastHit hit;
    [SerializeField] weaponinstantiate weapons;
    [SerializeField] weaponinstantiate hand_left;
    [SerializeField] weaponinstantiate hand_right;
    [SerializeField] GameObject cam;
    int weapon_diff;
    bool right_hand;
    bool left_hand;



    void What_weapon()
    {

        weapon_diff = weapons.GetComponent<weaponinstantiate>().weapon_diff;
        right_hand = hand_right.right_hand;
        left_hand = hand_left.left_hand;

        if (weapon_diff == 0 && right_hand == false ) //le 0 signifie main nue
        {
            Debug.DrawRay(transform.position, cam.transform.forward * 2, Color.red);
            
            //il faut que je crée le raycast 
        }
        if (weapon_diff == 1) //le 1 signfie la hache
        {
            Debug.DrawRay(transform.position, cam.transform.forward * 3.5f, Color.red);
        }
        if (weapon_diff == 2) //le 2 signifie la faussile
        {
            Debug.DrawRay(transform.position, cam.transform.forward * 2, Color.red);
        }
        if (weapon_diff == 3)// le 3 signifie la fouche
        {
            Debug.DrawRay(transform.position, cam.transform.forward * 4, Color.red);
            
        }
    }



    //fonction pour créer et voir un raycast
    void Weapon_collision_detected()
    {
        
   

    }
    private void Start()
    {
      
    }


    private void Update()
    {
        Weapon_collision_detected();
        What_weapon();
     
    }
}
