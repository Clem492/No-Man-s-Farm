using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
// using UnityEngine.Experimental.GlobalIllumination; // supprimé car inutile et source potentielle d’erreurs

public class spawn_zombie : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject zombie_prefab;
    [SerializeField] TMPro.TextMeshProUGUI jour_nuit;
    [SerializeField] TMPro.TextMeshProUGUI vague;
    [SerializeField] Light jour_nuit_lumiere; // corrigé (remplacement du caractère cassé)
    [SerializeField] GameObject girouette;
    GameObject[] tab_zombie = new GameObject[100000];
    public int[] tab_pv_zombie = new int[100000];
    public int nombre_zombie_spawn = 5;
    int numero_vague;
    int temp_jour;
    int temp_nuit;
    int lumiere_valeur; // corrigé (remplacement du caractère cassé)
    int depart = 0;
    int sauvgarde_depart;
    int zone_spawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawn());
        jour_nuit_lumiere.transform.rotation = Quaternion.Euler(90,0,0);
        girouette.transform.rotation = Quaternion.Euler(0, 0, 0);
        temp_jour = 10;
        temp_nuit = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawn()
    {
        while (true)
        {
            lumiere_valeur = 100;
            numero_vague += 1;
            temp_jour = 10;
            temp_nuit = 10;

            //affiche le jour
            jour_nuit.text = "jour";

            // Attendre ... s avant de faire la suite de la fonction (jour)
            for (int i = 0; i < temp_jour; i++)
            {
                jour_nuit_lumiere.transform.rotation = Quaternion.Euler(lumiere_valeur, 0, 0);
                Debug.Log("light");
                lumiere_valeur -= 10;
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
                    Debug.Log("Nord");
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
                    Debug.Log("Est");
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
                    Debug.Log("Sud");
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
                    Debug.Log("Ouest");
                    depart += 1;
                }
            }
            sauvgarde_depart = depart;
            //ont augmente le nombre de zombie qui va spawn
            nombre_zombie_spawn = nombre_zombie_spawn + 2;
            // Attendre ... s avant de faire la suite de la fonction (nuit)

            lumiere_valeur = -100;
            for (int i = 0; i < temp_nuit; i++)
            {
                jour_nuit_lumiere.transform.rotation = Quaternion.Euler(lumiere_valeur, 0, 0);
                Debug.Log("light2");
                lumiere_valeur += 10;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}