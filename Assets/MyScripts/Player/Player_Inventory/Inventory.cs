using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    const int Full_Inventory = 20;
    public List<Item_Data> content = new List<Item_Data>();
    public List<Image> slot_images = new List<Image>();
    
    public void Add_Item(Item_Data item)
    {
        content.Add(item);
    }

    public void Remove_Item(Item_Data item)
    {
        content.Remove(item);
        
    }

    //ouverture et fermeture de l'inventaire 

    [SerializeField] Canvas Inventory_ui;//Canva utiliser pour l'ui de l'inventaire
    [SerializeField] RawImage crosshaire;// récupération du crossaire pour le désactiver
    bool inventory_in_screen;//variable utiliser pour vérifier si le canva est bien afficher a l'écran
    //il faut que lorsque j'appuie sur une touche l'inventaire s'ouvre et se referme
    //il faut que mon viseur se désactive aussi 
    void open_inventory()
    {
        if (Input.GetKeyDown(KeyCode.I) && inventory_in_screen == false)
        {
            crosshaire.enabled = false;
            Inventory_ui.gameObject.SetActive(true);
            StartCoroutine(cooldown_open_inventory());
        }
    }
    void close_inventory()
    {
        if (Input.GetKeyDown(KeyCode.I) && inventory_in_screen == true)
        {
            crosshaire.enabled = true;
            Inventory_ui.gameObject.SetActive(false);
            StartCoroutine(cooldown_close_inventory());

        }
    }

    private void Start()
    {
        
        crosshaire.enabled = true;
        Inventory_ui.gameObject.SetActive(false);
        inventory_in_screen = false;
        
    }

    private void Update()
    {
        open_inventory();
        close_inventory();
        meat_in_inventory();
       Refresh_content();
        
    }

    void meat_in_inventory()
    {
        for (int i = 0; i < content.Count; i++)
        {
            if (content[i].Item_Name == "Steak" || content[i].Item_Name == "Egg")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (GameObject.FindWithTag("player").GetComponent<food_player>().food_player_actuelle <90)
                    {
                        slot_images[i].sprite = null;
                        Remove_Item(content[i]);
                        Refresh_content();
                        GameObject.FindWithTag("player").GetComponent<food_player>().gain_nourriture_player(10);
                        return;
                    }
                    
                }
            }
            
            
        }
    }

   public bool Inventory_Full()
    {
        return Full_Inventory == content.Count;
    }

    IEnumerator cooldown_open_inventory()//cette coroutine empêche que les fonction close et open se joue toute les deux en meme temps 
    {
        yield return new WaitForSeconds(0.1f);
        inventory_in_screen = true;
    }

    IEnumerator cooldown_close_inventory()
    {
        yield return new WaitForSeconds(0.1f);
        inventory_in_screen = false;
    }

    //affichage des élément de notre inventaire dans l'ui inventaire 
    [SerializeField] private Transform inventory_slot_parent;
    public void Refresh_content()
    {
        //  Efface tous les slots d'abord
        foreach (var img in slot_images)
        {
            img.sprite = null;
            
        }

        //  Puis affiche les items actuels dans l’ordre
        for (int i = 0; i < content.Count; i++)
        {
            slot_images[i].sprite = content[i].Item_Image;
            
        }
    }
}
