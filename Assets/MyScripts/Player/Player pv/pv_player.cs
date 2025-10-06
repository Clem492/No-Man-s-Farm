using UnityEngine;

public class pv_player : MonoBehaviour
{
    float nb_pv_player;
    [SerializeField] TMPro.TextMeshProUGUI txt_pv_joueur;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ont initialise les pv du joueur
        nb_pv_player = 10;
        //affiche pv joueur
        txt_pv_joueur.text = "PV : " + nb_pv_player;
    }

    // Update is called once per frame
    void Update()
    {
        mort_player();
    }
    //ont verifie si le joueur est mort
    void mort_player()
    {
        //si c'est point de vie sont a 0 ou en dessous de 0
        if (nb_pv_player <= 0)
            Destroy(gameObject);
    }
    //reduit les pv du joueur
    public void perte_pv_player(float degats)
    {
        nb_pv_player -= degats;
        //affiche pv joueur
        txt_pv_joueur.text = "PV : " + nb_pv_player;
    }
}
