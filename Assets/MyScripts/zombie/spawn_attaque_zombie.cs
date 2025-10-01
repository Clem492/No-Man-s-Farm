using UnityEngine;
using System.Collections;

public class spawn_attaque_zombie : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject zombie_prefabs;
    GameObject[] tab_zombie;
    int nombre_zombie_spawn = 5;
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


            // Attendre ... s avant de faire la suite de la fonction (jour)
            Debug.Log("jour");
            yield return new WaitForSeconds(10f);


            // Attendre ... s avant de faire la suite de la fonction (nuit)
            Debug.Log("nuit");
            for (int i = 0; i < nombre_zombie_spawn; i++)
            {
                tab_zombie[i] = Instantiate(zombie_prefabs,new Vector3(Random.Range(10,100),0.5f, Random.Range(10, 100)), Quaternion.identity);
                
            }
            nombre_zombie_spawn += 2;

            yield return new WaitForSeconds(10f);
            

          
           
        }
        
           
    }
}

