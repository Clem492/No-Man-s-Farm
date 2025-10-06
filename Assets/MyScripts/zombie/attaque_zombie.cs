using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class attaque_zombie : MonoBehaviour
{
    float degat_zombie = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            //si la distance entre le joueur et le zombie
            if (Vector3.Distance(GameObject.FindWithTag("player").transform.position, gameObject.transform.position) < 1.5f )
            {
                //ont appelle la fonction du script pv_player pour retirer des pv au joueur
                GameObject.FindWithTag("player").GetComponent<pv_player>().perte_pv_player(degat_zombie);
                //ont attend 1s avant de de pouvoir réinfligé des dégats
                yield return new WaitForSeconds(1f);
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
