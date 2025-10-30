using UnityEngine;
using System.Collections;


public class mouvement_cerf : MonoBehaviour
{
    [SerializeField] float vitesse_cerf = 2f;                
    [SerializeField] float temps_entre_deplacements = 10f; 

    Vector3 cible; 

    void Start()
    {
        
        StartCoroutine(ChangeDestination());
    }

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, cible, vitesse_cerf * Time.deltaTime);
        Vector3 direction = (cible - transform.position).normalized;
        if (direction != Vector3.zero)
            transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * 2f);
    }

    IEnumerator ChangeDestination()
    {
        while (true)
        {
            yield return new WaitForSeconds(temps_entre_deplacements);
            cible = new Vector3(Random.Range(10, 490), transform.position.y, Random.Range(10, 490));
        }
    }

    
}