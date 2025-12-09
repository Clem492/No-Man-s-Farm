using System.Collections;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// using UnityEngine.Experimental.GlobalIllumination; // supprimé car inutile et source potentielle d’erreurs

public class spawn_zombie : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject zombie_prefab;
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject boss_zombie_prefab;
    [SerializeField] GameObject cerf;
    [SerializeField] GameObject cerf_bugger;
    [SerializeField] GameObject farm;
    [SerializeField] GameObject jour, nuit;
   // [SerializeField] TMPro.TextMeshProUGUI jour_nuit;
    [SerializeField] TMPro.TextMeshProUGUI vague;
    [SerializeField] Light jour_nuit_lumiere; 
    [SerializeField] GameObject girouette;
    [SerializeField] GameObject poule;
    
    public int nombre_zombie_spawn = 7;
    public bool win;
    int numero_vague;
    int temp_jour;
    int temp_nuit;
    int lumiere_valeur; 
    int depart = 0;
    int sauvgarde_depart;
    int zone_spawn;
    int nb_cerf_spawn;
    string scene_win = "SceneVictoire";
    GameObject cerf_actuelle;
    //tutoriel
    public bool cycle_unlock;
    [SerializeField] bool cheat_code;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cycle_unlock = true;
        win = false;
        nb_cerf_spawn = 20;
        numero_vague = 0;
        jour_nuit_lumiere.transform.rotation = Quaternion.Euler(90,0,0);
        girouette.transform.rotation = Quaternion.Euler(0, 0, 0);
        temp_jour = 105;
        temp_nuit = 105;
        soleil.enabled = false;
        soleil_quart.enabled = false;
        soleil_demi.enabled = false;
        soleil_trois_quart.enabled = false;
        lune.enabled = false;
        lune_quart.enabled = false;
        lune_demi.enabled = false;
        lune_trois_quart.enabled = false;
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        switch_ui_cycle();
     
    }
   public IEnumerator spawn()
    {
        if (cycle_unlock)
        {

            jour.GetComponent<AudioSource>().enabled = true; //musique jour
            nuit.GetComponent<AudioSource>().enabled = false;//musique nuit desactiver
            if (win == true)
            {
                SceneManager.LoadScene(scene_win);
                yield break;
            }
            //spawn cerf
            if (numero_vague % 2 == 0)
            {
                for (int i = 0; i < nb_cerf_spawn; i++)
                {
                    cerf_actuelle = Instantiate(cerf, new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500)), Quaternion.identity);
                    if (Vector3.Distance(cerf_actuelle.transform.position, farm.transform.position) < 30)
                    {
                        Destroy(cerf_actuelle);
                    }
                }
                cerf_actuelle = Instantiate(cerf_bugger, new Vector3(Random.Range(0, 500), 0f, Random.Range(0, 500)), Quaternion.identity);
                cerf_actuelle = Instantiate(cerf_bugger, new Vector3(Random.Range(0, 500), 0f, Random.Range(0, 500)), Quaternion.identity);
            }

            lumiere_valeur = 105;
            numero_vague += 1;


            //affiche le jour
            // jour_nuit.text = "jour";

            // Attendre ... s avant de faire la suite de la fonction (jour)
            for (int i = 0; i < temp_jour; i++)
            {
                if (cheat_code)
                {
                    break;
                }
                jour_nuit_lumiere.transform.rotation = Quaternion.Euler(lumiere_valeur, 0, 0);

                lumiere_valeur -= 1;
                yield return new WaitForSeconds(1f);
                if (zombie.GetComponent<tutorial>().tutoriel)
                {
                    yield break;
                }
            }
            jour.GetComponent<AudioSource>().enabled = false;
            nuit.GetComponent<AudioSource>().enabled = true;

            //affiche la nuit
            // jour_nuit.text = "nuit";

            //affiche le numéro de la vague
            vague.text = "vague : " + numero_vague;
            zone_spawn = Random.Range(0, 4);
            //boss zombie
            if (numero_vague == 5)
            {
                Instantiate(boss_zombie_prefab, new Vector3(Random.Range(50, 150), 1.5f, Random.Range(150, 350)), Quaternion.identity);
                jour.GetComponent<AudioSource>().enabled = false;
                nuit.GetComponent<AudioSource>().enabled = false;
            }
            //ont instantie les zombie
            if (zone_spawn == 0)
            {
                //Nord
                for (int i = depart; i < nombre_zombie_spawn + sauvgarde_depart; i++)
                {
                   Instantiate(zombie_prefab, new Vector3(Random.Range(6, 38),1.5f, Random.Range(272, 310)), Quaternion.Euler(0,0,0));

                    girouette.transform.rotation = Quaternion.Euler(0, 44, 0);
                    yield return new WaitForSeconds(1f);
                    depart += 1;
                }
            }
            else if (zone_spawn == 1)
            {
                //Est
                for (int i = depart; i < nombre_zombie_spawn + sauvgarde_depart; i++)
                {
                     Instantiate(zombie_prefab, new Vector3(Random.Range(203, 224),1.5f, Random.Range(483, 496)), Quaternion.Euler(0, 0, 0));

                    girouette.transform.rotation = Quaternion.Euler(0, 134, 0);
                    yield return new WaitForSeconds(1f);
                    depart += 1;
                }
            }
            else if (zone_spawn == 2)
            {
                //Sud
                for (int i = depart; i < nombre_zombie_spawn + sauvgarde_depart; i++)
                {
                    Instantiate(zombie_prefab, new Vector3(Random.Range(483, 494), 1.5f, Random.Range(268, 302)), Quaternion.Euler(0, 0, 0));

                    girouette.transform.rotation = Quaternion.Euler(0, 224, 0);
                    yield return new WaitForSeconds(1f);
                    depart += 1;
                }
            }
            else
            {
                //Ouest
                for (int i = depart; i < nombre_zombie_spawn + sauvgarde_depart; i++)
                {
                    Instantiate(zombie_prefab, new Vector3(Random.Range(298, 314), 1.5f, Random.Range(2, 15)), Quaternion.Euler(0, 0, 0));

                    girouette.transform.rotation = Quaternion.Euler(0, 314, 0);
                    yield return new WaitForSeconds(1f);
                    depart += 1;
                }
            }
            sauvgarde_depart = depart;
            //ont augmente le nombre de zombie qui va spawn
            nombre_zombie_spawn = nombre_zombie_spawn + 2;
            // Attendre ... s avant de faire la suite de la fonction (nuit)

            lumiere_valeur = -105;
            for (int i = 0; i < temp_nuit; i++)
            {
                jour_nuit_lumiere.transform.rotation = Quaternion.Euler(lumiere_valeur, 0, 0);

                lumiere_valeur += 1;
                yield return new WaitForSeconds(1f);
            }
            poule.GetComponent<spawn_oeuf>().spawn_oeuf_vague();
            StartCoroutine(spawn());
        }
        
    }

    //affichage du soleil/lune
    [SerializeField] RawImage soleil, soleil_quart, soleil_demi, soleil_trois_quart;
    [SerializeField] RawImage lune, lune_quart, lune_demi, lune_trois_quart;
    private void switch_ui_cycle()
    {
        if(lumiere_valeur ==  104)
        {
            soleil.enabled = true;
            soleil_quart.enabled = false;
            soleil_demi.enabled = false;
            soleil_trois_quart.enabled = false;
            lune.enabled = false;
            lune_quart.enabled = false;
            lune_demi.enabled = false;
            lune_trois_quart.enabled = false;
        }
        if (lumiere_valeur == 79)
        {
            soleil.enabled = false;
            soleil_quart.enabled = true;
            soleil_demi.enabled = false;
            soleil_trois_quart.enabled = false;
            lune.enabled = false;
            lune_quart.enabled = false;
            lune_demi.enabled = false;
            lune_trois_quart.enabled = false;
        }
        if (lumiere_valeur == 53)
        {
            soleil.enabled = false;
            soleil_quart.enabled = false;
            soleil_demi.enabled = true;
            soleil_trois_quart.enabled = false;
            lune.enabled = false;
            lune_quart.enabled = false;
            lune_demi.enabled = false;
            lune_trois_quart.enabled = false;
        }
        if (lumiere_valeur == 27)
        {
            soleil.enabled = false;
            soleil_quart.enabled = false;
            soleil_demi.enabled = false;
            soleil_trois_quart.enabled = true;
            lune.enabled = false;
            lune_quart.enabled = false;
            lune_demi.enabled = false;
            lune_trois_quart.enabled = false;
        }
        if (lumiere_valeur == -104)
        {
            soleil.enabled = false;
            soleil_quart.enabled = false;
            soleil_demi.enabled = false;
            soleil_trois_quart.enabled = false;
            lune.enabled = true;
            lune_quart.enabled = false;
            lune_demi.enabled = false;
            lune_trois_quart.enabled = false;
        }
        if( lumiere_valeur == -79)
        {
            soleil.enabled = false;
            soleil_quart.enabled = false;
            soleil_demi.enabled = false;
            soleil_trois_quart.enabled = false;
            lune.enabled = false;
            lune_quart.enabled = true;
            lune_demi.enabled = false;
            lune_trois_quart.enabled = false;
        }
        if (lumiere_valeur == -53)
        {
            soleil.enabled = false;
            soleil_quart.enabled = false;
            soleil_demi.enabled = false;
            soleil_trois_quart.enabled = false;
            lune.enabled = false;
            lune_quart.enabled = false;
            lune_demi.enabled = true;
            lune_trois_quart.enabled = false;
        }
        if (lumiere_valeur == -27)
        {
            soleil.enabled = false;
            soleil_quart.enabled = false;
            soleil_demi.enabled = false;
            soleil_trois_quart.enabled = false;
            lune.enabled = false;
            lune_quart.enabled = false;
            lune_demi.enabled = false;
            lune_trois_quart.enabled = true;
        }
    }
    

}