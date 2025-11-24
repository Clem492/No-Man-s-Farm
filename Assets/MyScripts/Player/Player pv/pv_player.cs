using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.Mathematics;
public class pv_player : MonoBehaviour
{
    public float nb_pv_player;
    bool est_mort;
    [SerializeField] TMPro.TextMeshProUGUI txt_pv_player;
    string scene_loose = "SceneDefaite";
    //effet de sang
    [SerializeField] RawImage blood;
    [SerializeField] float blood_speed_disapering;
    bool blood_in_screen = false;
    RawImage img;
    Color C;
    void Start()
    {
        //ont initialise les pv du joueur
        nb_pv_player = 10;
        est_mort = false;
        //affiche pv joueur
        txt_pv_player.text = "PV : " + nb_pv_player;


        //effet de sang pas visible 
        img = blood;
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

   public void Blood_Effect()
    {
        //effet de sang pas visible 
        C = img.color;
        C.a = 1;
        img.color = C;
        blood_in_screen = true;
        StartCoroutine(FadeBlood());
    }

    private IEnumerator FadeBlood()
    {
        while (C.a > 0f)
        {
            // Diminue l'alpha progressivement
            C.a -= Time.deltaTime * blood_speed_disapering;
            C.a = Mathf.Clamp01(C.a); // S'assure que l'alpha reste entre 0 et 1
            img.color = C;

            yield return null; // Attend la prochaine frame
        }

        blood_in_screen = false; // Le sang a complètement disparu
    }

}
