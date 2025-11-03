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
    [SerializeField] GameObject Zombie;
    [SerializeField] GameObject Axe, pitchfork, sickle;
    bool can_attaque;
    bool next_step;
    bool mid_step_part2;
    bool mid_step_part3;
    [SerializeField] RawImage viseur;
    bool tutoriel;
    

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
        dialogue.text = "Tu peux également regarder au alentour avec la souris, tu ne trouve pas qu'il fait beau dehors ajourd'hui ?";
        Player.GetComponent<movement_player>().tutorial_cam = true;
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Maintenant que tu sais te déplacer, tu peux interagire avec une des arme derrière moi en appuyant sur E";
        yield return new WaitForSeconds(2.5f);
        zombie_sond.Stop();
        next_step = true;

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "Prend une arme";
        yield return new WaitForSeconds(2.5f);
        zombie_sond.Stop();
        next_step = true;

    }

    void take_weapon_tutorial()
    {
        if ((Vector3.Distance(Player.transform.position, Axe.transform.position) < 5 || Vector3.Distance(Player.transform.position, pitchfork.transform.position) < 5 || Vector3.Distance(Player.transform.position, sickle.transform.position) < 5) && can_attaque == false)
        {
            
            dialogue.text = "Press E to pick up";
            if (Input.GetKeyDown(KeyCode.E) && (Vector3.Distance(Player.transform.position, Axe.transform.position) < 5 || Vector3.Distance(Player.transform.position, pitchfork.transform.position) < 5 || Vector3.Distance(Player.transform.position, sickle.transform.position) < 5))
            {
                can_attaque = true;
                StartCoroutine(fin_dialogue_part1());
            }
        }
        else if (next_step && (Vector3.Distance(Player.transform.position, Axe.transform.position) > 5 || Vector3.Distance(Player.transform.position, pitchfork.transform.position) > 5 || Vector3.Distance(Player.transform.position, sickle.transform.position) > 5) && can_attaque == false)
        {
            Debug.Log("je suis trop loin");
            dialogue.text = "";
        }
        


    }

    IEnumerator fin_dialogue_part1()
    {
        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "tu peux aussi jeter tes armes pour en prendre de nouvelle en appuyan sur la touche X";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();

        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "lache une arme par terre";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();
        mid_step_part2 = true;
        StopCoroutine(fin_dialogue_part1());
        

    }

    IEnumerator fin_dialogue_part2()
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
        dialogue.text = "Prend une arme à deux main";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();
        mid_step_part3 = true;
        StopCoroutine (fin_dialogue_part2());

       
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
        dialogue.text = "désormer je vais te demander quelque chose de délicat...";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();
        
        yield return new WaitForSeconds(2);
        zombie_sond.Play();
        dialogue.text = "tu peux me tuer... je ne suis pas l'un de vous ! et tu sais comment te défendre.";
        yield return new WaitForSeconds(2);
        zombie_sond.Stop();
        
        Zombie.GetComponent<pv_zombie>().enabled = true;
        tutoriel = false;
        StopCoroutine(fin_dialogue_part3());
    }

    void press_x_to_continue()
    {
        if (mid_step_part2)
        {
           
            if (Input.GetKeyDown(KeyCode.X))
            {
                
                Debug.Log("je lance la part2");
                StartCoroutine(fin_dialogue_part2());
                
            }
        }
        


    }

    void take_double_hand_weapon()
    {
        if (mid_step_part3)
        {
           
            
            if (mid_step_part3 && (Vector3.Distance(Player.transform.position, Axe.transform.position) < 5 || Vector3.Distance(Player.transform.position, pitchfork.transform.position) < 5 || Vector3.Distance(Player.transform.position, sickle.transform.position) < 5) && Input.GetKeyDown(KeyCode.E))
            {
                bool double_hant = true;
                if (double_hant && Input.GetKeyDown(KeyCode.E) && (Vector3.Distance(Player.transform.position, Axe.transform.position) < 5 || Vector3.Distance(Player.transform.position, pitchfork.transform.position) < 5 || Vector3.Distance(Player.transform.position, sickle.transform.position) < 5))
                {
                    StartCoroutine(fin_dialogue_part3());
                }
            }
        }
       
    }

    void visual_crossair()
    {
        if (tutoriel)
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
        
    }

    private void Start()
    {
        next_step = false;
        StartCoroutine(debut_dialogue());
        zombie_sond.enabled = false;
        can_attaque = false;
        Zombie.GetComponent<pv_zombie>().enabled = false;
        mid_step_part2 = false;
        mid_step_part3 = false;
        tutoriel = true;
        
    }
}
