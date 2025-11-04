using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System.Collections;
//ce sript utilise weapon instantiate
public class weapon_attaque : MonoBehaviour
{
    //variable pour le raycast
    RaycastHit hit;
    [SerializeField] weaponinstantiate weapons_created;
    [SerializeField] weaponinstantiate hand_left;
    [SerializeField] weaponinstantiate hand_right;
    [SerializeField] GameObject cam;
    [SerializeField] AudioSource son_weapon;
   public int weapon_diff;
    bool right_hand;
    bool left_hand;



    //variable pour la sphère cast
    Collider[] enemies;
    

   

    //dégat pour les différente arme
    float hand_dommage;
    float axe_dommage;
    float axe_dommage_tree;
    float sickle_dommage;
    float pitchfork_dommage;
    int rarety;
    float double_hand_dammage = 1.5f;

    //utile pour la coroutine anti_spam
    bool can_attaque;
    //variable pour le tuto
    public bool clique_unlock;

    //fonction pour savoir quelle arme le joueur a en main
    public void What_weapon()
      {

          weapon_diff = weapons_created.GetComponent<weaponinstantiate>().weapon_diff;
          right_hand = hand_right.right_hand;
          left_hand = hand_left.left_hand;

        if (weapon_diff == 0 && right_hand == false && clique_unlock == true ) //le 0 signifie main nue
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * 2, Color.red);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(transform.position, cam.transform.forward, out hit, 4))
                {


                    if (hit.transform.GetComponent<pv_zombie>())
                    {
                        hand_dommage = 2;
                        hit.transform.GetComponent<pv_zombie>().perte_pv_zombie(hand_dommage);
                    }
                    if (hit.transform.GetComponent<pv_cerf>())
                    {

                      hand_dommage = rarety * (double_hand_dammage * 7); ;
                      hit.transform.GetComponent<pv_cerf>().perte_pv_cerf(hand_dommage);
                    }


                }
            }

        }

        if (weapon_diff == 1 && can_attaque == true && clique_unlock == true) //le 1 signfie la hache
          {
            //raycast en boule pour toucher plus d'enemie
            //il faut faire la hache
            enemies = Physics.OverlapSphere(cam.transform.position + cam.transform.forward * 2f, 2);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                son_weapon.Play();
                can_attaque = false;
                StartCoroutine(anti_spam_axe());
              
            }


        }
          if (weapon_diff == 2 && can_attaque == true && clique_unlock == true) //le 2 signifie la faussile
          {
              Debug.DrawRay(transform.position, cam.transform.forward * 2, Color.red);
              if (Input.GetKeyDown(KeyCode.Mouse0))
              {
                son_weapon.Play();
                can_attaque = false;
                  if (Physics.Raycast(transform.position, cam.transform.forward, out hit, 4))
                  {
                    StartCoroutine(anti_spam_sickle());

                  }
                else
                {
                    StartCoroutine(reset_anim_sickle());
                }
              }
          }
       
        if (weapon_diff == 3 && can_attaque == true && clique_unlock == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                son_weapon.Play();
                can_attaque = false;
                Debug.DrawRay(cam.transform.position, cam.transform.forward * 4, Color.red);
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 4))
                {

                    StartCoroutine(anti_spam_pitfork());

                }
                else
                {
                    StartCoroutine(reset_anim_pitchfork());
                }
            }
        }

        
    }
    IEnumerator anti_spam_axe()// permet de faire les dégat mais aussi d'avoir le temps d'attente
    {
        foreach (Collider col in enemies)
        {
            if (col.transform.GetComponent<pv_zombie>())
            {
                axe_dommage = rarety * (double_hand_dammage * 7);
                col.transform.GetComponent<pv_zombie>().perte_pv_zombie(axe_dommage);
            }
            if (col.transform.GetComponent<pv_arbre>())
            {

                axe_dommage_tree = 1;
                col.transform.GetComponent<pv_arbre>().perte_pv_arbre(axe_dommage_tree);
            }
            if (col.transform.GetComponent<pv_cerf>())
            {

                axe_dommage = rarety * (double_hand_dammage * 7); ;
                col.transform.GetComponent<pv_cerf>().perte_pv_cerf(axe_dommage);
            }
            if (col.transform.GetComponent<pv_arbre_mort>())
            {
                axe_dommage_tree = 1;
                col.transform.GetComponent<pv_arbre_mort>().perte_pv_arbre(axe_dommage_tree);
            }
           

        }
        yield return new WaitForSeconds(1.7f);
        can_attaque = true;
  
    }
   



    IEnumerator anti_spam_sickle()
    {
        if (hit.transform.GetComponent<pv_zombie>())
        {
            sickle_dommage = rarety * (double_hand_dammage * 5);
            hit.transform.GetComponent<pv_zombie>().perte_pv_zombie(sickle_dommage);
        }
        if (hit.transform.GetComponent<pv_cerf>())
        {

            sickle_dommage = rarety * (double_hand_dammage * 5);
            hit.transform.GetComponent<pv_cerf>().perte_pv_cerf(sickle_dommage);
        }
        yield return new WaitForSeconds(1.1f);
        can_attaque = true;
    }
    IEnumerator reset_anim_sickle()
    {
        yield return new WaitForSeconds(1.1f);
        can_attaque = true;
    }







    IEnumerator anti_spam_pitfork()
    {
        
        if (hit.transform.GetComponent<pv_zombie>() )
        {
            float pitchfork_dommage = 8;
            hit.transform.GetComponent<pv_zombie>().perte_pv_zombie(pitchfork_dommage);
            Debug.Log("Zombie touché !");
            
        }
        if (hit.transform.GetComponent<pv_cerf>())
        {

            pitchfork_dommage = 8;
            hit.transform.GetComponent<pv_cerf>().perte_pv_cerf(pitchfork_dommage);
        }
        yield return new WaitForSeconds(1.5f);
        can_attaque = true;
        
    }

    IEnumerator reset_anim_pitchfork()
    {
        yield return new WaitForSeconds(1.5f);
        can_attaque = true;
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


   
    private void Start()
    {
        rarety = 1;
        can_attaque = true;
        
    }


    private void Update()
    {
        What_weapon();
        Double_hand_active();
     
    }
}
