using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.AI;

public class attaque_zombie : MonoBehaviour
{
    float degat_zombie = 1f;
    float degat_zombie_boss = 2f;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        //on lance la fonction dps zombie
        StartCoroutine(dps_zombie());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator dps_zombie()
    {
        while (true)
        {
            if (gameObject.CompareTag("boss"))
            {
                if (Vector3.Distance(GameObject.FindWithTag("player").transform.position, gameObject.transform.position) < 4f)
                {
                    //ont appelle la fonction du script pv_player pour retirer des pv au joueur
                    GameObject.FindWithTag("player").GetComponent<pv_player>().perte_pv_player(degat_zombie_boss);
                    //ont attend 1s avant de de pouvoir réinfligé des dégats
                    gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    gameObject.GetComponent<mouvement_zombie>().enabled = false;
                    animator.SetTrigger("attaque_zombie");
                    yield return new WaitForSeconds(1f);
                    gameObject.GetComponent<NavMeshAgent>().enabled = true;
                    gameObject.GetComponent<mouvement_zombie>().enabled = true;
                }
            }
            //si la distance entre le joueur et le zombie
            else if (Vector3.Distance(GameObject.FindWithTag("player").transform.position, gameObject.transform.position) < 2f )
            {
                //ont appelle la fonction du script pv_player pour retirer des pv au joueur
                GameObject.FindWithTag("player").GetComponent<pv_player>().perte_pv_player(degat_zombie);
                //ont attend 1s avant de de pouvoir réinfligé des dégats
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                gameObject.GetComponent<mouvement_zombie>().enabled = false;
                animator.SetTrigger("attaque_zombie");
                yield return new WaitForSeconds(1f);
                gameObject.GetComponent<NavMeshAgent>().enabled = true;
                gameObject.GetComponent<mouvement_zombie>().enabled = true;
            }
            yield return new WaitForSeconds(0.1f);
            //si le player n'existe plus ont sort de la boucle
            if(GameObject.FindWithTag("player") == null)
            {
                yield break;
            }
        }
        
        
    }
}
