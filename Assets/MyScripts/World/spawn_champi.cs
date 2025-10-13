
using UnityEngine;

public class spawn_champi : MonoBehaviour
{
    GameObject[] tab_rock_prefabs;
    GameObject[] tab_champi;
    [SerializeField] GameObject champi_1, champi_2, champi_3, champi_4, champi_5, champi_6;
    int indice_champi_aleatoire;
    [SerializeField] GameObject farm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tab_rock_prefabs = new GameObject[6];
        tab_champi = new GameObject[500];
        // Remplissage du tableau
        tab_rock_prefabs[0] = champi_1;
        tab_rock_prefabs[1] = champi_2;
        tab_rock_prefabs[2] = champi_3;
        tab_rock_prefabs[3] = champi_4;
        tab_rock_prefabs[4] = champi_5;
        tab_rock_prefabs[5] = champi_6;
        spawn_champi_fonction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawn_champi_fonction()
    {
        for (int i = 0; i < tab_champi.Length; i++)
        {
            indice_champi_aleatoire = Random.Range(0, 6);
            tab_champi[i] = Instantiate(tab_rock_prefabs[indice_champi_aleatoire], new Vector3(Random.Range(0, 500), 0f, Random.Range(0, 500)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            if (Vector3.Distance(tab_champi[i].transform.position, farm.transform.position) < 25)
            {
                Destroy(tab_champi[i]);
            }
        }
    }
}
