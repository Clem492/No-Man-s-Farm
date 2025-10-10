
using UnityEngine;

public class spawn_arbre : MonoBehaviour
{
    GameObject[] tab_arbre = new GameObject[1000];
    GameObject[] tab_arbre_mort = new GameObject[100];
    [SerializeField] GameObject arbre_prefab;
    [SerializeField] GameObject arbre_mort_prefab;
    [SerializeField] GameObject farm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < tab_arbre.Length; i++)
        {
            tab_arbre[i] = Instantiate(arbre_prefab, new Vector3(Random.Range(0, 500), 0f, Random.Range(0, 500)), Quaternion.identity);
            if (Vector3.Distance(tab_arbre[i].transform.position, farm.transform.position) < 20)
            {
                Destroy(tab_arbre[i]);
            }
        }
        for (int i = 0; i < tab_arbre_mort.Length; i++)
        {
            tab_arbre_mort[i] = Instantiate(arbre_mort_prefab, new Vector3(Random.Range(0, 500), 0.5f, Random.Range(0, 500)), Quaternion.Euler(0,Random.Range(0,360),0));
            if (Vector3.Distance(tab_arbre_mort[i].transform.position, farm.transform.position) < 20)
            {
                Destroy(tab_arbre_mort[i]);
            }
        }
    }
    /*float random_exclusion(float min,float max , float exclu_min , float exclu_max)
    {
        float result = Random.Range(min,max);
        while(result >= exclu_min && result <= exclu_max)
        {
            result = Random.Range(min, max);
        }
        return result;
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
