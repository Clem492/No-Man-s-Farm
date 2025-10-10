using Unity.VisualScripting;
using UnityEngine;

public class animation : MonoBehaviour
{
 //il faut récupérer quel arme est en main 
    GameObject player;
    [SerializeField] int weapon_diff;
    //il faut aussi récupérer la main gauche ou droite du joueur
     Animator animator;
    private void Update()
    {
        player = GameObject.FindWithTag("player");
        weapon_diff =  player.GetComponent<weapon_attaque>().weapon_diff; //je récupe quelle arme est en main
        animation_weapon();
        
    }
    //fonction pour savoir quelle animation en fonction de quelle arme
    void animation_weapon()
    {
        if (weapon_diff == 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
        if (weapon_diff == 1 && Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
        if (weapon_diff == 2 && Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
        if (weapon_diff == 3 && Input.GetKeyDown(KeyCode.Mouse0) && player.GetComponent<weaponinstantiate>().weapon_hand == true)
        {
            animator.SetTrigger("Attack");
            
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
