using System.Collections;
using UnityEngine;

public class pv_zombie : MonoBehaviour
{

    public float nb_pv_zombie;
    Animator animator;

    [SerializeField] TMPro.TextMeshProUGUI affichage_pv_zombie;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nb_pv_zombie = 50;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mort_zombie();
        affichage_pv_zombie.text = "PV : " + nb_pv_zombie;
    }
    //ont verifie si le zombie est mort
    void mort_zombie()
    {
        //si c'est point de vie sont a 0 ou en dessous de 0
        if (nb_pv_zombie <= 0)
        {
            StartCoroutine(anim_mort_zombie());
        }
    }
    //reduit les pv du zombie
    public void perte_pv_zombie(float degats)
    {
        nb_pv_zombie -= degats;
        
        animator.SetTrigger("degat_zombie");
    }
    IEnumerator anim_mort_zombie()
    {
        animator.SetTrigger("mort_zombie");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
