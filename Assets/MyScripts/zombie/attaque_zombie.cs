using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class attaque_zombie : MonoBehaviour
{
    float degat_zombie = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            if (Vector3.Distance(GameObject.FindWithTag("player").transform.position, gameObject.transform.position) < 1.2)
            {
                GameObject.FindWithTag("player").GetComponent<pv_player>().perte_pv_player(degat_zombie);
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(0.1f);

            if(GameObject.FindWithTag("player") == null)
            {
                yield break;
            }
        }
        
        
    }
}
