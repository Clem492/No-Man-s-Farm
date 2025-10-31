using UnityEngine;
using System.Collections;


public class pv_arbre : MonoBehaviour
{
    public float nb_pv_arbre;
    [SerializeField] GameObject souche;
    [SerializeField] GameObject branche;
    
    Animator animator;

    void Start()
    {
        nb_pv_arbre = 3;
        animator = GetComponentInChildren<Animator>();
        gameObject.GetComponent<AudioSource>().enabled = false;
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
        StartCoroutine(audio_arbre());
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
        for (int i = 0; i < Random.Range(1,4); i++)
        {
            Instantiate(branche,new Vector3(gameObject.transform.position.x,3,gameObject.transform.position.z), Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
        Destroy(gameObject);
    }
    IEnumerator audio_arbre()
    {
        gameObject.GetComponent<AudioSource>().enabled =true;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<AudioSource>().enabled = false;
    }
}
