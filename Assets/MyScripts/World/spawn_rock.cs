
using UnityEngine;

public class spawn_rock : MonoBehaviour
{
    GameObject[] tab_rock_prefabs;
    GameObject[] tab_rock;
    [SerializeField] GameObject rock_1, rock_2, rock_3 ;
    int indice_rock_aleatoire;
    [SerializeField] GameObject farm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tab_rock_prefabs = new GameObject[3];
        tab_rock = new GameObject[500];
        // Remplissage du tableau
        tab_rock_prefabs[0] = rock_1;
        tab_rock_prefabs[1] = rock_2;
        tab_rock_prefabs[2] = rock_3;
        
        spawn_rock_fonction();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawn_rock_fonction()
    {
        for (int i = 0; i < tab_rock.Length; i++)
        {
            indice_rock_aleatoire = Random.Range(0, 3);
            tab_rock[i] = Instantiate(tab_rock_prefabs[indice_rock_aleatoire], new Vector3(Random.Range(0, 500), 0f, Random.Range(0, 500)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            if (Vector3.Distance(tab_rock[i].transform.position, farm.transform.position) < 25)
            {
                Destroy(tab_rock[i]);
            }
        }
    }
}

