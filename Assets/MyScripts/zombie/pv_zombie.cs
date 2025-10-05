using UnityEngine;

public class pv_zombie : MonoBehaviour
{
    float nb_pv_zombie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nb_pv_zombie = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void mort_zombie()
    {
        if (nb_pv_zombie <= 0) 
            Destroy(gameObject);
    }
    void perte_pv_zombie(float degats)
    {
        nb_pv_zombie -= degats;
    }
}
