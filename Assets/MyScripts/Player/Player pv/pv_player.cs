using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class pv_player : MonoBehaviour
{
    public float nb_pv_player;
    bool est_mort;
    [SerializeField] TMPro.TextMeshProUGUI txt_pv_player;
    string scene_loose = "SceneDefaite";
    //effet de sang
    [SerializeField] RawImage blood;
    
    [SerializeField] float blood_transparency;
    void Start()
    {
        //ont initialise les pv du joueur
        nb_pv_player = 10;
        est_mort = false;
        //affiche pv joueur
        txt_pv_player.text = "PV : " + nb_pv_player;


        //effet de sang pas visible 
        RawImage img = blood;
        Color C = img.color;
        C.a = 0;
        img.color = C;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //affiche pv joueur
        txt_pv_player.text = "PV : " + nb_pv_player;
        mort_player();
        
    }
    //ont verifie si le joueur est mort
    public void mort_player()
    {
        //si c'est point de vie sont a 0 ou en dessous de 0
        if (nb_pv_player <= 0 && !est_mort)
        {
            
            est_mort = true;
            SceneManager.LoadScene(scene_loose);

        }
            
    }
    public void mort_player_food()
    {
        SceneManager.LoadScene(scene_loose);
    }
    
    //reduit les pv du joueur
    public void perte_pv_player(float degats)
    {
        nb_pv_player -= degats;
        
        
    }
   

   
}
