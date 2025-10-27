using UnityEngine;
using System.Collections;

public class pv_arbre : MonoBehaviour
{
    public float nb_pv_arbre;
    [SerializeField] GameObject souche;
    Animator animator;

    void Start()
    {
        nb_pv_arbre = 3;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        destruction_arbre();
    }
    public void perte_pv_arbre(float degats)
    {
        nb_pv_arbre -= degats;
        animator.SetTrigger("degat_arbre");
        
    }
    void destruction_arbre()
    {
        if (nb_pv_arbre <= 0)
        {
            
            StartCoroutine(anim_destruction_arbre());
        }
           
    }
    IEnumerator anim_destruction_arbre()
    {
        //animator.SetTrigger("destrution_arbre");
        
        yield return new WaitForSeconds(1f);
        Instantiate(souche, gameObject.transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
        Destroy(gameObject);
    }
}
