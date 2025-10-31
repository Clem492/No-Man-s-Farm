using UnityEngine;
using UnityEngine.UI;

public class food_player : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI txt_food_player;
    [SerializeField] RawImage food_1, food_2, food_3, food_4, food_5, food_6, food_7, food_8, food_9, food_10;
    [SerializeField] RawImage food_vide_1, food_vide_2, food_vide_3, food_vide_4, food_vide_5, food_vide_6, food_vide_7, food_vide_8, food_vide_9, food_vide_10;
    public float food_player_actuelle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        food_player_actuelle = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
        perte_nourriture_player();
        changement_image_food();
    }
    void mort_faim()
    {
        if(food_player_actuelle <= 0)
        {
            gameObject.GetComponent<pv_player>().mort_player();
        }
    }
    void perte_nourriture_player()
    {
        food_player_actuelle -= 0.25f * Time.deltaTime;
    }
    void gain_nourriture_player(float val_nourriture)
    {
        if((food_player_actuelle + val_nourriture)<100)
        {
            food_player_actuelle += val_nourriture;
        }
        else
        {
            food_player_actuelle = 100;
        }
             
        
    }
    void changement_image_food()
    {
        if (food_player_actuelle <= 0)
        {
            food_1.enabled = false;
            food_vide_1.enabled = true;
        }
        if (food_player_actuelle <= 10)
        {
            food_2.enabled = false;
            food_vide_2.enabled = true;
        }
        if (food_player_actuelle <= 20)
        {
            food_3.enabled = false;
            food_vide_3.enabled = true;
        }
        if (food_player_actuelle <= 30)
        {
            food_4.enabled = false;
            food_vide_4.enabled = true;
        }
        if (food_player_actuelle <= 40)
        {
            food_5.enabled = false;
            food_vide_5.enabled = true;
        }
        if (food_player_actuelle <= 50)
        {
            food_6.enabled = false;
            food_vide_6.enabled = true;
        }
        if (food_player_actuelle <= 60)
        {
            food_7.enabled = false;
            food_vide_7.enabled = true;
        }
        if (food_player_actuelle <= 70)
        {
            food_8.enabled = false;
            food_vide_8.enabled = true;
        }
        if (food_player_actuelle <= 80)
        {
            food_9.enabled = false;
            food_vide_9.enabled = true;
        }
        if (food_player_actuelle <= 90)
        {
            food_10.enabled = false;
            food_vide_10.enabled = true;
        }
        if (food_player_actuelle >= 0)
        {
            food_1.enabled = true;
            food_vide_1.enabled = false;
        }
        if (food_player_actuelle >= 10)
        {
            food_2.enabled = true;
            food_vide_2.enabled = false;
        }
        if (food_player_actuelle >= 20)
        {
            food_3.enabled = true;
            food_vide_3.enabled = false;
        }
        if (food_player_actuelle >= 30)
        {
            food_4.enabled = true;
            food_vide_4.enabled = false;
        }
        if (food_player_actuelle >= 40)
        {
            food_5.enabled = true;
            food_vide_5.enabled = false;
        }
        if (food_player_actuelle >= 50)
        {
            food_6.enabled = true;
            food_vide_6.enabled = false;
        }
        if (food_player_actuelle >= 60)
        {
            food_7.enabled = true;
            food_vide_7.enabled = false;
        }
        if (food_player_actuelle >= 70)
        {
            food_8.enabled = true;
            food_vide_8.enabled = false;
        }
        if (food_player_actuelle >= 80)
        {
            food_9.enabled = true;
            food_vide_9.enabled = false;
        }
        if (food_player_actuelle >= 90)
        {
            food_10.enabled = true;
            food_vide_10.enabled = false;
        }
    }
}
