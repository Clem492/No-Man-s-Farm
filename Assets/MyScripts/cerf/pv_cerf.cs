using UnityEngine;
using System.Collections;

public class pv_cerf : MonoBehaviour

{
    public float nb_pv_cerf;
    [SerializeField] GameObject viande;
    bool mort;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nb_pv_cerf = 20;
        mort = false;
    }

    // Update is called once per frame
    void Update()
    {
        mort_cerf();
    }
    void mort_cerf()
    {
        if(nb_pv_cerf <= 0 && mort == false)
        {
            StartCoroutine(spawn_viande());
            mort = true;
            
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
            Instantiate(viande, new Vector3(gameObject.transform.position.x, 1f, gameObject.transform.position.z), Quaternion.Euler(0, Random.Range(0, 360), 0));
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
        }
        
    }
}
