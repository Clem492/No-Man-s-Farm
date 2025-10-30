using UnityEngine;
using System.Collections;

public class pv_cerf : MonoBehaviour

{
    public float nb_pv_cerf;
    [SerializeField] GameObject viande;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nb_pv_cerf = 20;
    }

    // Update is called once per frame
    void Update()
    {
        mort_cerf();
    }
    void mort_cerf()
    {
        if(nb_pv_cerf <= 0)
        {
            StartCoroutine(spawn_viande());
          
            
        }
    }
    public void perte_pv_cerf(float degats)
    {
        nb_pv_cerf -= degats;
        
    }
    IEnumerator spawn_viande()
    {
        for (int i = 0; i < Random.Range(2, 4); i++)
        {
            Instantiate(viande, new Vector3(gameObject.transform.position.x, 2.5f, gameObject.transform.position.z), Quaternion.Euler(0, Random.Range(0, 360), 0));
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
        }
        
    }
}
