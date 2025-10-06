using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class spawn_zombie : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject zombie_prefabs;
    [SerializeField] TMPro.TextMeshProUGUI jour_nuit;
    [SerializeField] TMPro.TextMeshProUGUI vague;
    GameObject[] tab_zombie =new GameObject[1000];
    int[] tab_pv_zombie = new int[1000];
    public int nombre_zombie_spawn = 5;
    int numero_vague;
    
    int depart = 0;
    int sauvgarde_depart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

            numero_vague += 1;
            
            
            //affiche le jour
            jour_nuit.text = "jour";

            // Attendre ... s avant de faire la suite de la fonction (jour)
            yield return new WaitForSeconds(10f);


            //affiche la nuit
            jour_nuit.text = "nuit";
          
            //affiche le numéro de la vague
            vague.text = "vague : " + numero_vague;
            //ont instantie les zombie
            for (int i = depart; i < nombre_zombie_spawn+sauvgarde_depart; i++)
            {
                tab_zombie[i] = Instantiate(zombie_prefabs,new Vector3(Random.Range(10,100),0.5f, Random.Range(10, 100)), Quaternion.identity);
                
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