using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI dialogue;
    [SerializeField] AudioSource zombie_sond;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject Zombie;
    [SerializeField] GameObject world;
    [SerializeField] GameObject Axe, pitchfork, sickle;
    [SerializeField] GameObject mur_tuto_move, mur_porte1, mur_porte2;
    bool can_attaque;
    bool next_step;
    bool mid_step_part2;
    bool mid_step_part3;
    [SerializeField] RawImage viseur;
    public bool tutoriel;
    bool crosshair;
    bool tuto_fini;

    void lancment_tuto_move()
    {
        if (Vector3.Distance(Player.transform.position, Zombie.transform.position) < 4 && tutoriel == false)
        {
            dialogue.text = "press E to talk (Start tutorial)";
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                
                
                Player.transform.position = new Vector3(250, 1, 239);
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
                cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
                Player.GetComponent<movement_player>().movement_x = 0;
                Player.GetComponent<movement_player>().movement_y = 0;
                Player.GetComponent<movement_player>().xRotation = 0;
                Player.GetComponent<movement_player>().cam_x = 0;
                Player.GetComponent<movement_player>().cam_y = 0;
                Player.GetComponent<weaponinstantiate>().touche_x_unclock = false;
                Player.GetComponent<weaponinstantiate>().double_hand_unlock = false;
                Player.GetComponent<weapon_attaque>().clique_unlock = false;
                Player.GetComponent<movement_player>().can_move_forward = false;
                Player.GetComponent<movement_player>().can_move_right = false;
                Player.GetComponent<movement_player>().tutorial_cam = false;
                world.GetComponent<spawn_zombie>().cycle_unlock = false;
                mur_tuto_move.SetActive(true);
                mur_porte1.SetActive(true);
                mur_porte2.SetActive(true);
                next_step = false;
                StartCoroutine(debut_dialogue());
                can_attaque = false;
                mid_step_part2 = false;
                mid_step_part3 = false;
                tutoriel = true;
                crosshair = true;

            }
        }
        else if (Vector3.Distance(Player.transform.position, Zombie.transform.position) > 4 && tutoriel == false)
        {
            dialogue.text = "";
        }
    }


    

    IEnumerator debut_dialogue()
    {
       
        yield return new WaitForSeconds(2);
        zombie_sond.enabled = true;
        dialogue.text = "Bonjour toi humain, moi être steve zombie, mais moi me sentir homme";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Alors je t'apprendre a déplacer !";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Pour avancer toi appuyer sur touche Z";
        Player.GetComponent<movement_player>().tutorial_move = 1;
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Pour reculer toi appuyer sur touche S";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Pour aller à gauche toi appuyer sur touche Q";
        Player.GetComponent<movement_player>().tutorial_move = 2;
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Pour aller à droite toi appuyer sur touche D";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "toi pouvoir sauter quand toi appuyer espace";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Tu peux également regarder au alentour avec la souris, tu ne trouve pas qu'il fait beau dehors ajourd'hui ?";
        Player.GetComponent<movement_player>().tutorial_cam = true;
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Maintenant que tu sais te déplacer, tu peux interagire avec une des arme derrière moi en appuyant sur E";
        yield return new WaitForSeconds(3f);
        zombie_sond.Stop();
        next_step = true;
        mur_tuto_move.SetActive(false);

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Prend une arme";
        yield return new WaitForSeconds(2.5f);
        zombie_sond.Stop();
        

    }

    void take_weapon_tutorial()
    {
        if ((Vector3.Distance(Player.transform.position, Axe.transform.position) < 5 || Vector3.Distance(Player.transform.position, pitchfork.transform.position) < 5 || Vector3.Distance(Player.transform.position, sickle.transform.position) < 5) && can_attaque == false)
        {
            
            dialogue.text = "Press E to pick up";
            if (Input.GetKeyDown(KeyCode.E) && (Vector3.Distance(Player.transform.position, Axe.transform.position) < 5 || Vector3.Distance(Player.transform.position, pitchfork.transform.position) < 5 || Vector3.Distance(Player.transform.position, sickle.transform.position) < 5))
            {
                can_attaque = true;
                StartCoroutine(debut_dialogue_part1());
            }
        }
        else if (next_step && (Vector3.Distance(Player.transform.position, Axe.transform.position) > 5 || Vector3.Distance(Player.transform.position, pitchfork.transform.position) > 5 || Vector3.Distance(Player.transform.position, sickle.transform.position) > 5) && can_attaque == false)
        {
            Debug.Log("je suis trop loin");
            dialogue.text = "Prend une arme";
        }
        


    }

    IEnumerator debut_dialogue_part1()
    {
        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "tu peux aussi jeter tes armes pour en prendre de nouvelle";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "lache une arme par terre en appuyan sur la touche X";
        Player.GetComponent<weaponinstantiate>().touche_x_unclock = true;
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();
        mid_step_part2 = true;
        StopCoroutine(debut_dialogue_part1());
        

    }

    IEnumerator mid_dialogue_part2()
    {
        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "il y a des armes que tu peux porter à deux main ou pas !";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Par exemple tu peux prendre 2 faussil ou 2 hache en appuyant 2 fois sur E, mais tu ne peux pas prendre 2 fourche ! c'est une arme à deux main.";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Prend deux armes";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();
        Player.GetComponent<weaponinstantiate>().double_hand_unlock = true;
        mid_step_part3 = true;
        StopCoroutine (mid_dialogue_part2());

       
    }

    IEnumerator fin_dialogue_part3()
    {
        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Fait attention ! tu n'as qu'une seul vie.";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Tu peux mourir en te faisant tuer par un zombie mais aussi de faim !";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Tu peux voir ta vie grace au PV en haut de ton écran et ta faim en bas à gauche avec les steacks";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "En tant que zombie je peux te dire que nous détestons le jour";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "fait attendtion a l'heure de la journée ! visible sur la petit horloge en haut à gauche de l'écran.";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "tu peux appuyer sur le clique gauche pour tapper !";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "c'est bon je t'ai tous appris.";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();
        
        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "bonne chance !";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();
        Player.GetComponent<weapon_attaque>().clique_unlock = true;
        crosshair = false;
        tutoriel = false;
        tuto_fini = true;
        mur_porte1.SetActive(false);
        mur_porte2.SetActive(false);
        dialogue.enabled = false;
        world.GetComponent<spawn_zombie>().cycle_unlock = true;
        StopCoroutine(fin_dialogue_part3());
    }

    void press_x_to_continue()
    {
        if (mid_step_part2)
        {
           
            if (Input.GetKeyDown(KeyCode.X))
            {
                
                Debug.Log("je lance la part2");
                StartCoroutine(mid_dialogue_part2());
                mid_step_part2 = false;
            }
        }
        


    }

    void take_double_hand_weapon()
    {
        if (mid_step_part3)
        {
           
            
            if (mid_step_part3 && (Vector3.Distance(Player.transform.position, Axe.transform.position) < 5 || Vector3.Distance(Player.transform.position, pitchfork.transform.position) < 5 || Vector3.Distance(Player.transform.position, sickle.transform.position) < 5) && Input.GetKeyDown(KeyCode.E))
            {
                
                if (Player.GetComponent<weaponinstantiate>().left_hand == true && Player.GetComponent<weaponinstantiate>().right_hand == true && Input.GetKeyDown(KeyCode.E) && (Vector3.Distance(Player.transform.position, Axe.transform.position) < 5 || Vector3.Distance(Player.transform.position, pitchfork.transform.position) < 5 || Vector3.Distance(Player.transform.position, sickle.transform.position) < 5))
                {
                    StartCoroutine(fin_dialogue_part3());
                }
            }
        }
       
    }

   
    void final_step()
    {
        if (world.GetComponent<spawn_zombie>().cycle_unlock == true && tutoriel == false && tuto_fini)
        {
            Debug.Log("entrer dans le truc de la coroutine");
            StartCoroutine(world.GetComponent<spawn_zombie>().spawn());
            tuto_fini = false;
        }
    }

    void visual_crossair()
    {
        if (crosshair)
        {
            viseur.gameObject.SetActive(false);
        }
        else
        {
            viseur.gameObject.SetActive(true);
        }
    }
    
  


    private void Update()
    {
        take_weapon_tutorial();
        press_x_to_continue();
        take_double_hand_weapon();
        visual_crossair();
        lancment_tuto_move();
        final_step();
    }

    private void Start()
    {
       
        tuto_fini = false;
        tutoriel = false;
        world.GetComponent<spawn_zombie>().cycle_unlock = true;
        Player.GetComponent<weaponinstantiate>().touche_x_unclock = true;
        Player.GetComponent<weaponinstantiate>().double_hand_unlock = true;
        Player.GetComponent<movement_player>().can_move_forward = true;
        Player.GetComponent<movement_player>().can_move_right = true;
        Player.GetComponent<movement_player>().tutorial_cam = true;
        Player.GetComponent<weapon_attaque>().clique_unlock = true;
        Zombie.GetComponent<pv_zombie>().enabled = false;
        crosshair = false;
        zombie_sond.enabled = false;
        mur_tuto_move.SetActive(false);
        mur_porte1.SetActive(false);
        mur_porte2.SetActive(false);

    }
}
