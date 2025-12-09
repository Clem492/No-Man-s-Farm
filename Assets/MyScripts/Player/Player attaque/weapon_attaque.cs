
using UnityEditor;
using UnityEngine;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
//ce sript utilise weapon instantiate
public class weapon_attaque : MonoBehaviour
{
    //variable pour le raycast
    RaycastHit hit;
    [SerializeField] GameObject sang;
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
    float gun_dommage;



    int rarety;
    float double_hand_dammage = 1.5f;

    //utile pour la coroutine anti_spam
    public bool can_attaque;
    //variable pour le tuto
    public bool clique_unlock;

 
    int bullet = 20;
    int dura_arme_droite;
    int dura_arme_gauche;
    
    [SerializeField] TextMeshProUGUI bullet_text;

    //fonction pour savoir quelle arme le joueur a en main
    public void What_weapon()
    {

        weapon_diff = weapons_created.GetComponent<weaponinstantiate>().weapon_diff;
        right_hand = hand_right.right_hand;
        left_hand = hand_left.left_hand;

        if (weapon_diff == 0 && right_hand == false && clique_unlock == true) //le 0 signifie main nue
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * 2, Color.red);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(transform.position, cam.transform.forward, out hit, 4))
                {


                    if (hit.transform.GetComponent<pv_zombie>())
                    {
                        Instantiate(sang, hit.point, Quaternion.identity);
                        hand_dommage = 1;
                        hit.transform.GetComponent<pv_zombie>().perte_pv_zombie(hand_dommage);
                        if (hand_right.hand_right != null)
                        {
                            hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
                        }
                        if (hand_left.hand_left != null)
                        {
                            hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
                        }
                    }
                    if (hit.transform.GetComponent<pv_cerf>())
                    {
                        Instantiate(sang, hit.point, Quaternion.identity);
                        hand_dommage = 1;
                        hit.transform.GetComponent<pv_cerf>().perte_pv_cerf(hand_dommage);
                        if (hand_right.hand_right != null)
                        {
                            hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
                        }
                        if (hand_left.hand_left != null)
                        {
                            hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
                        }
                    }
                    if (hit.transform.GetComponent<pv_poule>())
                    {
                        Instantiate(sang, hit.point, Quaternion.identity);
                        axe_dommage_tree = 1;
                        hit.transform.GetComponent<pv_poule>().retirer_pv_poule(1);
                        if (hand_right.hand_right != null)
                        {
                            hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
                        }
                        if (hand_left.hand_left != null)
                        {
                            hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
                        }
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

        if (weapon_diff == 4 && can_attaque && clique_unlock == true)
        {
            
            
            
            
            if (bullet != 0 && weapons_created.right_hand)
            {
                bullet_text.enabled = true;
                bullet_text.text = bullet + "/20";
                
                
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    
                    can_attaque = false;
                    Debug.DrawRay(cam.transform.position, cam.transform.forward * 70, Color.red);
                    if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 70))
                    {
                        
                        StartCoroutine(anti_spam_gun());
                        if (bullet <= 0 )
                        {
                            GameObject[] a_detruire;
                            a_detruire = GameObject.FindGameObjectsWithTag("chiant");
                            foreach(GameObject game in a_detruire)
                            {
                                weapons_created.right_hand = false;
                                Destroy(game);

                            }
                            bullet_text.enabled = false;
                        }
                        
                    }
                    else
                    {
                        bullet -= 1;
                        bullet_text.text = bullet + "/20";
                        StartCoroutine(reset_anim_gun());
                        if (bullet <= 0)
                        {
                            GameObject[] a_detruire;
                            a_detruire = GameObject.FindGameObjectsWithTag("chiant");
                            foreach (GameObject game in a_detruire)
                            {
                                weapons_created.right_hand = false;
                                Destroy(game);

                            }
                            bullet_text.enabled = false;
                        }
                    }

                }
            }

        }
        else if (!weapons_created.right_hand)
        {

            bullet_text.enabled = false;
            bullet = 20;
        }



    }
    IEnumerator anti_spam_axe()// permet de faire les dégat mais aussi d'avoir le temps d'attente
    {
        foreach (Collider col in enemies)
        {
            if (col.transform.GetComponent<pv_zombie>())
            {

                axe_dommage = rarety * (double_hand_dammage * 5);
                col.transform.GetComponent<pv_zombie>().perte_pv_zombie(axe_dommage);
                if (hand_right.hand_right != null)
                {
                    hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
                }
                if (hand_left.hand_left != null)
                {
                    hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
                }
            }
            if (col.transform.GetComponent<pv_arbre>())
            {

                axe_dommage_tree = 1;
                col.transform.GetComponent<pv_arbre>().perte_pv_arbre(axe_dommage_tree);
                if (hand_right.hand_right != null)
                {
                    hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
                }
                if (hand_left.hand_left != null)
                {
                    hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
                }
            }
            if (col.transform.GetComponent<pv_cerf>())
            {

                axe_dommage = rarety * (double_hand_dammage * 5); ;
                col.transform.GetComponent<pv_cerf>().perte_pv_cerf(axe_dommage);
                if (hand_right.hand_right != null)
                {
                    hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
                }
                if (hand_left.hand_left != null)
                {
                    hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
                }
            }
            if (col.transform.GetComponent<pv_arbre_mort>())
            {
                axe_dommage_tree = 1;
                col.transform.GetComponent<pv_arbre_mort>().perte_pv_arbre(axe_dommage_tree);
                if (hand_right.hand_right != null)
                {
                    hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
                }
                if (hand_left.hand_left != null)
                {
                    hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
                }
            }
            if (col.transform.GetComponent<pv_poule>())
            {
                axe_dommage_tree = 1;
                col.transform.GetComponent<pv_poule>().retirer_pv_poule(1);
                if (hand_right.hand_right != null)
                {
                    hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
                }
                if (hand_left.hand_left != null)
                {
                    hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
                }
            }


        }
        yield return new WaitForSeconds(1.7f);
        can_attaque = true;

    }

    IEnumerator anti_spam_gun()
    {
        
        gun_dommage = rarety * (double_hand_dammage * 20);
        if (hit.transform.GetComponent<pv_zombie>())
        {
            Instantiate(sang, hit.point, Quaternion.identity);
            hit.transform.GetComponent<pv_zombie>().perte_pv_zombie(gun_dommage);
        }
        if (hit.transform.GetComponent<pv_cerf>())
        {

            Instantiate(sang, hit.point, Quaternion.identity);
            hit.transform.GetComponent<pv_cerf>().perte_pv_cerf(gun_dommage);
        }
        if (hit.transform.GetComponent<pv_poule>())
        {
            Instantiate(sang, hit.point, Quaternion.identity);
            hit.transform.GetComponent<pv_poule>().retirer_pv_poule(1);
        }
        bullet -= 1;
        bullet_text.text =  bullet + "/20";
        yield return new WaitForSeconds(1.5f);
        can_attaque = true;
    }


    IEnumerator reset_anim_gun()
    {
        yield return new WaitForSeconds(1.5f);
        can_attaque = true;
    }

    IEnumerator anti_spam_sickle()
    {
        if (hit.transform.GetComponent<pv_zombie>())
        {
            Instantiate(sang, hit.point, Quaternion.identity);
            sickle_dommage = rarety * (double_hand_dammage * 7);
            hit.transform.GetComponent<pv_zombie>().perte_pv_zombie(sickle_dommage);
            if (hand_right.hand_right != null)
            {
                hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
            }
            if (hand_left.hand_left != null)
            {
                hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
            }
        }
        if (hit.transform.GetComponent<pv_cerf>())
        {
            Instantiate(sang, hit.point, Quaternion.identity);
            sickle_dommage = rarety * (double_hand_dammage * 7);
            hit.transform.GetComponent<pv_cerf>().perte_pv_cerf(sickle_dommage);

            if (hand_right.hand_right != null)
            {
                hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
            }
            if (hand_left.hand_left != null)
            {
                hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
            }
        }
        if (hit.transform.GetComponent<pv_poule>())
        {
            Instantiate(sang, hit.point, Quaternion.identity);
            axe_dommage_tree = 1;
            hit.transform.GetComponent<pv_poule>().retirer_pv_poule(1);
            if (hand_right.hand_right != null)
            {
                hand_right.hand_right.GetComponent<dura_arme>().retirer_dura();
            }
            if (hand_left.hand_left != null)
            {
                hand_left.hand_left.GetComponent<dura_arme>().retirer_dura();
            }
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

        if (hit.transform.GetComponent<pv_zombie>())
        {
            Instantiate(sang, hit.point, Quaternion.identity);
            float pitchfork_dommage = 10;
            hit.transform.GetComponent<pv_zombie>().perte_pv_zombie(pitchfork_dommage);


        }
        if (hit.transform.GetComponent<pv_cerf>())
        {
            Instantiate(sang, hit.point, Quaternion.identity);
            pitchfork_dommage = 10;
            hit.transform.GetComponent<pv_cerf>().perte_pv_cerf(pitchfork_dommage);
        }
        if (hit.transform.GetComponent<pv_poule>())
        {
            Instantiate(sang, hit.point, Quaternion.identity);
            axe_dommage_tree = 1;
            hit.transform.GetComponent<pv_poule>().retirer_pv_poule(1);
        }
        yield return new WaitForSeconds(1.3f);
        can_attaque = true;

    }

    IEnumerator reset_anim_pitchfork()
    {
        yield return new WaitForSeconds(1.3f);
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