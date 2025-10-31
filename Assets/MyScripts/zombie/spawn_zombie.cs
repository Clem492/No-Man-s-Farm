using System.Collections;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
// using UnityEngine.Experimental.GlobalIllumination; // supprimé car inutile et source potentielle d’erreurs

public class spawn_zombie : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject zombie_prefab;
    [SerializeField] GameObject cerf;
    [SerializeField] GameObject farm;
    [SerializeField] GameObject jour, nuit;
    [SerializeField] TMPro.TextMeshProUGUI jour_nuit;
    [SerializeField] TMPro.TextMeshProUGUI vague;
    [SerializeField] Light jour_nuit_lumiere; 
    [SerializeField] GameObject girouette;
    [SerializeField] GameObject poule;
    GameObject[] tab_zombie = new GameObject[100000];
    public int[] tab_pv_zombie = new int[100000];
    public int nombre_zombie_spawn = 5;
    int numero_vague;
    int temp_jour;
    int temp_nuit;
    int lumiere_valeur; 
    int depart = 0;
    int sauvgarde_depart;
    int zone_spawn;
    int nb_cerf_spawn;
    GameObject cerf_actuelle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nb_cerf_spawn = 20;
        numero_vague = 0;
        jour_nuit_lumiere.transform.rotation = Quaternion.Euler(90,0,0);
        girouette.transform.rotation = Quaternion.Euler(0, 0, 0);
        temp_jour = 90;
        temp_nuit = 90;
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawn()
    {
        while (true)
        {
            if (numero_vague%5 ==0)
            {
                for (int i = 0; i < nb_cerf_spawn; i++)
                {
                    cerf_actuelle = Instantiate(cerf, new Vector3(Random.Range(0, 500), 0f, Random.Range(0, 500)), Quaternion.identity);
                    if (Vector3.Distance(cerf_actuelle.transform.position, farm.transform.position) < 30)
                    {
                        Destroy(cerf_actuelle);
                    }
                }
                
            }
            
            lumiere_valeur = 90;
            numero_vague += 1;
            

            //affiche le jour
            jour_nuit.text = "jour";

            // Attendre ... s avant de faire la suite de la fonction (jour)
            for (int i = 0; i < temp_jour; i++)
            {
                jour_nuit_lumiere.transform.rotation = Quaternion.Euler(lumiere_valeur, 0, 0);
                
                lumiere_valeur -= 1;
                yield return new WaitForSeconds(1f);
            }
            
            
            //affiche la nuit
            jour_nuit.text = "nuit";
          
            //affiche le numéro de la vague
            vague.text = "vague : " + numero_vague;
            zone_spawn = Random.Range(0, 4);
            //ont instantie les zombie

            if(zone_spawn == 0)
            {
                //Nord
                for (int i = depart; i < nombre_zombie_spawn + sauvgarde_depart; i++)
                {
                    tab_zombie[i] = Instantiate(zombie_prefab, new Vector3(Random.Range(50, 150), 1.5f, Random.Range(150, 350)), Quaternion.identity);
                    
                    girouette.transform.rotation = Quaternion.Euler(0, 44, 0);
                    
                    depart += 1;
                }
            }
            else if (zone_spawn == 1)
            {
                //Est
                for (int i = depart; i < nombre_zombie_spawn + sauvgarde_depart; i++)
                {
                    tab_zombie[i] = Instantiate(zombie_prefab, new Vector3(Random.Range(150, 350), 1.5f, Random.Range(350, 450)), Quaternion.identity);
                    
                    girouette.transform.rotation = Quaternion.Euler(0, 134, 0);
                   
                    depart += 1;
                }
            }
            else if (zone_spawn == 2)
            {
                //Sud
                for (int i = depart; i < nombre_zombie_spawn + sauvgarde_depart; i++)
                {
                    tab_zombie[i] = Instantiate(zombie_prefab, new Vector3(Random.Range(350, 450), 1.5f, Random.Range(150, 350)), Quaternion.identity);
                    
                    girouette.transform.rotation = Quaternion.Euler(0, 224, 0);
                   
                    depart += 1;
                }
            }
            else
            {
                //Ouest
                for (int i = depart; i < nombre_zombie_spawn + sauvgarde_depart; i++)
                {
                    tab_zombie[i] = Instantiate(zombie_prefab, new Vector3(Random.Range(150, 350), 1.5f, Random.Range(50, 150)), Quaternion.identity);
                   
                    girouette.transform.rotation = Quaternion.Euler(0, 314, 0);
                   
                    depart += 1;
                }
            }
            sauvgarde_depart = depart;
            //ont augmente le nombre de zombie qui va spawn
            nombre_zombie_spawn = nombre_zombie_spawn + 2;
            // Attendre ... s avant de faire la suite de la fonction (nuit)

            lumiere_valeur = -90;
            for (int i = 0; i < temp_nuit; i++)
            {
                jour_nuit_lumiere.transform.rotation = Quaternion.Euler(lumiere_valeur, 0, 0);
               
                lumiere_valeur += 1;
                yield return new WaitForSeconds(1f);
            }
            poule.GetComponent<spawn_oeuf>().spawn_oeuf_vague();
        }
    }
}