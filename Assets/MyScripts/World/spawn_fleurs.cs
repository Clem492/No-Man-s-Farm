
using UnityEngine;

public class spawn_fleurs : MonoBehaviour
{
    GameObject[] tab_fleur_prefabs;
    GameObject[] tab_fleur;
    [SerializeField] GameObject fleur_1, fleur_2, fleur_3 ;
    int indice_fleur_aleatoire;
    [SerializeField] GameObject farm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tab_fleur_prefabs = new GameObject[3];
        tab_fleur = new GameObject[2000];
        // Remplissage du tableau
        tab_fleur_prefabs[0] = fleur_1;
        tab_fleur_prefabs[1] = fleur_2;
        tab_fleur_prefabs[2] = fleur_3;
        
        spawn_fleur_fonction();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawn_fleur_fonction()
    {
        for (int i = 0; i < tab_fleur.Length; i++)
        {
            indice_fleur_aleatoire = Random.Range(0, 3);
            tab_fleur[i] = Instantiate(tab_fleur_prefabs[indice_fleur_aleatoire], new Vector3(Random.Range(0, 500), 0f, Random.Range(0, 500)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            if (Vector3.Distance(tab_fleur[i].transform.position, farm.transform.position) < 25)
            {
                Destroy(tab_fleur[i]);
            }
        }
    }
}

