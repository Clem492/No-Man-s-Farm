using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.Experimental.GlobalIllumination;

public class spawn_zombie : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject zombie_prefab;
    [SerializeField] TMPro.TextMeshProUGUI jour_nuit;
    [SerializeField] TMPro.TextMeshProUGUI vague;
    [SerializeField] Light jour_nuit_lumière;
    GameObject[] tab_zombie =new GameObject[100000];
    public int[] tab_pv_zombie = new int[100000];
    public int nombre_zombie_spawn = 5;
    int numero_vague;
    int temp_jour;
    int temp_nuit;
    int lumière_valeur;
    int depart = 0;
    int sauvgarde_depart;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawn());
        jour_nuit_lumière.transform.rotation = Quaternion.Euler(90,0,0);
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
            lumière_valeur = 100;
            numero_vague += 1;
            
            
            //affiche le jour
            jour_nuit.text = "jour";

            // Attendre ... s avant de faire la suite de la fonction (jour)
            for (int i = 0; i < temp_jour; i++)
            {
                jour_nuit_lumière.transform.rotation = Quaternion.Euler(lumière_valeur, 0, 0);
                lumière_valeur -= 10;
                yield return new WaitForSeconds(1f);
            }
            lumière_valeur = -100;
            for (int i = 0; i < temp_jour; i++)
            {
                jour_nuit_lumière.transform.rotation = Quaternion.Euler(lumière_valeur, 0, 0);
                lumière_valeur += 10;
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(10f);
            

            //affiche la nuit
            jour_nuit.text = "nuit";
          
            //affiche le numéro de la vague
            vague.text = "vague : " + numero_vague;
            //ont instantie les zombie
            for (int i = depart; i < nombre_zombie_spawn+sauvgarde_depart; i++)
            {
                tab_zombie[i] = Instantiate(zombie_prefab,new Vector3(Random.Range(10,100),1.5f, Random.Range(10, 100)), Quaternion.identity);
                
                depart += 1;
            }
            sauvgarde_depart = depart;
            //ont augmente le nombre de zombie qui va spawn
            nombre_zombie_spawn = nombre_zombie_spawn + 2;
            // Attendre ... s avant de faire la suite de la fonction (nuit)
            yield return new WaitForSeconds(10f);
            

          
           
        }
        
           
    }
    
}