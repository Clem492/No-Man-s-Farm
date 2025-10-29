using UnityEngine;
using System.Collections;


public class pv_arbre_mort : MonoBehaviour
{
    public float nb_pv_arbre_mort;
    [SerializeField] GameObject branche;
    Animator animator;

    void Start()
    {
        nb_pv_arbre_mort = 3;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        destruction_arbre_mort();
    }
    public void perte_pv_arbre(float degats)
    {
        nb_pv_arbre_mort -= degats;
        animator.SetTrigger("degat_arbre");
        
    }
    void destruction_arbre_mort()
    {
        if (nb_pv_arbre_mort <= 0)
        {
            
            for (int i = 0; i < Random.Range(2, 5); i++)
            {
                Instantiate(branche, new Vector3(gameObject.transform.position.x, 3, gameObject.transform.position.z), Quaternion.Euler(0, Random.Range(0, 360), 0));
            }
            Destroy(gameObject);
        }
           
    }
    
}
