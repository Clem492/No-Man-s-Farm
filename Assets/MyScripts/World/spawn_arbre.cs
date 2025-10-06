using UnityEngine;

public class spawn_arbre : MonoBehaviour
{
    GameObject[] tab_arbre = new GameObject[3000];
    [SerializeField] GameObject arbre_prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < tab_arbre.Length; i++)
        {
            tab_arbre[i] = Instantiate(arbre_prefab, new Vector3(Random.Range(20, 500), 2f, Random.Range(20, 500)), Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
