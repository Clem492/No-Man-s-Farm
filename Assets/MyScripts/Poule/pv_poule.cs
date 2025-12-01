using UnityEngine;

public class pv_poule : MonoBehaviour
{
    int nb_pv_poule;
    [SerializeField] GameObject prefab_dino;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void retirer_pv_poule()
    {
        Instantiate(prefab_dino, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
