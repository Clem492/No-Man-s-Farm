using UnityEngine;

public class spawn_arbre : MonoBehaviour
{
    GameObject[] tab_arbre = new GameObject[10000];
    [SerializeField] GameObject arbre_prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < tab_arbre.Length; i++)
        {
            tab_arbre[i] = Instantiate(arbre_prefab, new Vector3(random_exclusion(0,1000,480,520), 0f, random_exclusion(0, 1000, 480, 520)), Quaternion.identity);

        }
    }
    float random_exclusion(float min,float max , float exclu_min , float exclu_max)
    {
        float result = Random.Range(min,max);
        while(result >= exclu_min && result <= exclu_max)
        {
            result = Random.Range(min, max);
        }
        return result;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
