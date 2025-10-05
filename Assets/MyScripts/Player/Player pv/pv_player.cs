using UnityEngine;

public class pv_player : MonoBehaviour
{
    float nb_pv_player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nb_pv_player = 10;
    }

    // Update is called once per frame
    void Update()
    {
        mort_player();
    }
    void mort_player()
    {
        if (nb_pv_player <= 0)
            Destroy(gameObject);
    }
    public void perte_pv_player(float degats)
    {
        nb_pv_player -= degats;
    }
}
