using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class animation : MonoBehaviour
{
 //il faut récupérer quel arme est en main 
    GameObject player;
    [SerializeField] int weapon_diff;
    //il faut aussi récupérer la main gauche ou droite du joueur
     Animator animator;
    // il faut savoir si il est possible de jouer l'animation 
    public bool can_attaque1;
    [SerializeField] bool attaque;
    
    private void Update()
    {
     
        player = GameObject.FindWithTag("player");
        weapon_diff =  player.GetComponent<weapon_attaque>().weapon_diff; //je récupe quelle arme est en main
        animation_weapon();
        
    }
    //fonction pour savoir quelle animation en fonction de quelle arme
    void animation_weapon()
    {
        if (weapon_diff == 0 && Input.GetKeyDown(KeyCode.Mouse0) && can_attaque1 == true)
        {

        }
        if (weapon_diff == 1 && Input.GetKeyDown(KeyCode.Mouse0) && can_attaque1 == true)
        {
            can_attaque1 = false;
            StartCoroutine(axe_anim());
        }
        if (weapon_diff == 2 && Input.GetKeyDown(KeyCode.Mouse0) && can_attaque1 == true)
        {
            can_attaque1 = false;
            StartCoroutine(sickle_anim());
        }
        if (weapon_diff == 3 && Input.GetKeyDown(KeyCode.Mouse0) && player.GetComponent<weaponinstantiate>().weapon_hand == true && can_attaque1 == true)
        {
            can_attaque1 = false;
            StartCoroutine(pitforck_anim());
        }
        if (weapon_diff == 4 && Input.GetKeyDown(KeyCode.Mouse0) && can_attaque1 == true)
        {
            
            
            attaque = true;
            can_attaque1 = false;
            GetComponent<explosion>().lancement_explosion();
            animator.SetTrigger("attaque 0");
            StartCoroutine(gun_anim());
        }
   
    }

    IEnumerator axe_anim()
    {
        animator.SetTrigger("axe_attack");
        Debug.Log("la touche est appuyer");
        yield return new WaitForSeconds(1.7f);
        can_attaque1 = true;
    }

    IEnumerator pitforck_anim()
    {
        animator.SetTrigger("pitchfork_attack");
        yield return new WaitForSeconds(1.5f);
        can_attaque1 = true;
    }

    IEnumerator sickle_anim()
    {
        animator.SetTrigger("sickle_attack");
        yield return new WaitForSeconds(1f);
        can_attaque1 = true;
    }

    IEnumerator gun_anim()
    {
        
    
        yield return new WaitForSeconds(1.5f);
        attaque = false;

        can_attaque1 = true;


    }

    private void Start()
    {

       
        animator = GetComponent<Animator>();
        
        can_attaque1 = true;
       
        
        
    }
}
