using UnityEngine;

public class pv_zombie : MonoBehaviour
{
    float nb_pv_zombie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ont initialise les pv du du zombie
        nb_pv_zombie = 3;
    }

    // Update is called once per frame
    void Update()
    {
        mort_zombie();
    }
    //ont verifie si le zombie est mort
    void mort_zombie()
    {
        //si c'est point de vie sont a 0 ou en dessous de 0
        if (nb_pv_zombie <= 0) 
            Destroy(gameObject);
    }
    //reduit les pv du zombie
    public void perte_pv_zombie(float degats)
    {
        nb_pv_zombie -= degats;
    }
}
