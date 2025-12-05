using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class food_player : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI txt_food_player;
    [SerializeField] RawImage food_1, food_2, food_3, food_4, food_5, food_6, food_7, food_8, food_9, food_10;
    [SerializeField] RawImage food_vide_1, food_vide_2, food_vide_3, food_vide_4, food_vide_5, food_vide_6, food_vide_7, food_vide_8, food_vide_9, food_vide_10;
    bool verif_food_1, verif_food_2, verif_food_3, verif_food_4, verif_food_5, verif_food_6, verif_food_7, verif_food_8, verif_food_9,verif_food_10;
    bool[] tab_verif = new bool[10];
    public float food_player_actuelle;
    [SerializeField] float duree_zoom ,grossisement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        verif_food_1 = false;
        verif_food_2 = false;
        verif_food_3 = false;
        verif_food_4 = false;
        verif_food_5 = false;
        verif_food_6 = false;
        verif_food_7 = false;
        verif_food_8 = false;
        verif_food_9 = false;
        verif_food_10 = false;
        tab_verif[0] = verif_food_1;
        tab_verif[1] = verif_food_2;
        tab_verif[2] = verif_food_3;
        tab_verif[3] = verif_food_4;
        tab_verif[4] = verif_food_5;
        tab_verif[5] = verif_food_6;
        tab_verif[6] = verif_food_7;
        tab_verif[7] = verif_food_8;
        tab_verif[8] = verif_food_9;
        tab_verif[9] = verif_food_10;
        food_player_actuelle = 100;
    }

    // Update is called once per frame
    void Update()
    {
        perte_nourriture_player();
        changement_image_food();
        mort_faim();
       
    }
    void mort_faim()
    {
        if(food_player_actuelle <= 0)
        {
            gameObject.GetComponent<pv_player>().mort_player_food();
        }
    }
    void perte_nourriture_player()
    {
        food_player_actuelle -= 0.40f * Time.deltaTime;
    }
    public void gain_nourriture_player(float val_nourriture)
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
            if (!verif_food_1)
                StartCoroutine(grossisement_food(food_1, food_vide_1,0));
        }
        if (food_player_actuelle <= 10)
        {
            if (!verif_food_2)
                StartCoroutine(grossisement_food(food_2, food_vide_2,1));
        }
        if (food_player_actuelle <= 20)
        {
            if (!verif_food_3)
                StartCoroutine(grossisement_food(food_3, food_vide_3,2));
        }
        if (food_player_actuelle <= 30)
        {
            if (!verif_food_4)
                StartCoroutine(grossisement_food(food_4, food_vide_4,3));
        }
        if (food_player_actuelle <= 40)
        {
            if (!verif_food_5)
                StartCoroutine(grossisement_food(food_5, food_vide_5,4));
        }
        if (food_player_actuelle <= 50)
        {
            if (!verif_food_6)
                StartCoroutine(grossisement_food(food_6, food_vide_6,5));
        }
        if (food_player_actuelle <= 60)
        {
            if (!verif_food_7)
                StartCoroutine(grossisement_food(food_7, food_vide_7,6));
        }
        if (food_player_actuelle <= 70)
        {
            if (!verif_food_8)
                StartCoroutine(grossisement_food(food_8, food_vide_8,7));
            
        }
        if (food_player_actuelle <= 80)
        {
            if (!verif_food_9)
                StartCoroutine(grossisement_food(food_9, food_vide_9, 8));
    
        }
        if (food_player_actuelle <= 90)
        {
            if (!verif_food_10)
            {
                verif_food_1 = true;
                StartCoroutine(grossisement_food(food_10, food_vide_10, 9));
            }
               
            
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
    IEnumerator grossisement_food(RawImage food_image, RawImage food_image_vide,int i)
    {
        tab_verif[i] = true;
        LeanTween.scale(food_image.GetComponent<RectTransform>(), food_image.GetComponent<RectTransform>().localScale * grossisement, duree_zoom)
                 .setEaseOutQuad();
        yield return new WaitForSeconds(duree_zoom);
        food_image.enabled = false;
        food_image_vide.enabled = true;
        tab_verif[i] = false;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(duree_zoom) ;
    }
}
