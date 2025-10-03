using UnityEngine;

public class player_attaque : MonoBehaviour
{
    //variable pour la hache
    [SerializeField] GameObject axe;



    //fonction pour l'attaque du joueur 
    void apply_attaque()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           
        }
    }
    private void Update()
    {
        apply_attaque();
    }

}
