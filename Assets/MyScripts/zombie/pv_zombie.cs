using System.Collections;
using UnityEngine;

public class pv_zombie : MonoBehaviour
{

    public float nb_pv_zombie;
    Animator animator;
    [SerializeField] GameObject nails_prefab;
    [SerializeField] TMPro.TextMeshProUGUI affichage_pv_zombie;
    int luck_nail;
    bool mort;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nb_pv_zombie = 50;
        animator = GetComponent<Animator>();
        mort = false;
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
        if (nb_pv_zombie <= 0 && mort == false)
        {
            StartCoroutine(anim_mort_zombie());
            mort = true;
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
        luck_nail = Random.Range(0, 4);
        if (luck_nail <= 2)
        {
            Instantiate(nails_prefab, new Vector3(gameObject.transform.position.x, 1f, gameObject.transform.position.z), Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
              
        if (luck_nail == 0)
        {
            Instantiate(nails_prefab, new Vector3(gameObject.transform.position.x, 1f, gameObject.transform.position.z), Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
