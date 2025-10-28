using UnityEngine;

public class pv_cerf : MonoBehaviour
{
    public float nb_pv_cerf;
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
            Destroy(gameObject);
        }
    }
    public void perte_pv_cerf(float degats)
    {
        nb_pv_cerf -= degats;
        Debug.Log(nb_pv_cerf);
    }
}
