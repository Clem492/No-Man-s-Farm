using UnityEngine;

public class pv_poule : MonoBehaviour
{
    float nb_pv_poule;
    [SerializeField] GameObject prefab_dino;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nb_pv_poule = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        poule_mort();
    }
    public void retirer_pv_poule(float degat)
    {
        nb_pv_poule -= degat;
    }
    void poule_mort()
    {
        if(nb_pv_poule <= 0)
        {
            Instantiate(prefab_dino, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
