using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class craft : MonoBehaviour
{
    [SerializeField] Image bois; //récupération de l'image ou est afficher le bois 
    [SerializeField] Image clou; //récupération de l'image ou est afficher les clous
    [SerializeField] RawImage craft_final; //récupération de l'image du craft final
    [SerializeField] TMPro.TextMeshProUGUI bois_text; //utiliser pour savoir nous avons combien de bois et combien coute le craft pour cette ressource
    [SerializeField] TMPro.TextMeshProUGUI clou_text; //utiliser pour savoir nous avons combien de bois et combien coute le craft pour cette ressource
    [SerializeField] Sprite bois_sprite; //permet d'afficher le matériaux bois
    [SerializeField] Sprite clou_sprite; //permet d'afficher le matériaux clou 
    [SerializeField] Texture axe; //permet de visualiser le craft final de la hache
    [SerializeField] Texture pitchfork; //permet de visualiser le craft final de la pitchfork
    [SerializeField] Texture faussille; //permet de visualiser le craft final de la faussille
    [SerializeField] Inventory inventory;//permet de récuper la liste des items
    [SerializeField] weaponinstantiate weaponinstantiate; //permet de récupérer la fonction what_whand_craft
    //[SerializeField] AudioSource hammer; // récupération du bruit de craft
    public int bois_requis; //nombre de bois que le joueur a besoins de dépenser pour un craft
    public int clou_requis; //nombre de clou que le joueur a besoins de dépenser pour un craft
    public int wood_in_inventory; //combien le joueur à de bois dans son inventaire
    public int nails_in_inventory; //combien de clou le joueur à dans son inventaire
    public int what_craft; //permet de savoir quelle arme intentier quand le bouton craft est appuyer
    
    //au lancement le système de craft se cale sur la hache
    private void Start()
    {
        what_craft = 1;
        bois.sprite = bois_sprite;
        clou.sprite = clou_sprite;
        craft_final.texture = axe;
        bois_requis = 5;
        clou_requis = 3;
    }

    //acutualise les texte pour savoir combien de matériaux sont nécessaire et combien nous en avons
    private void Update()
    {
        bois_text.text = wood_in_inventory + "/" + bois_requis;
        clou_text.text = nails_in_inventory +"/" + clou_requis;
    }

    //permet de récupérer chaque item dans l'inventaire avec le nom wooden stick
    public void Wood()
    {
       int i = 0;
        foreach (Item_Data item in inventory.content)
        {
            if (item.Item_Name == "Wooden Stick")
            {
                i++;
                wood_in_inventory = i;
                
            }
        }
    }

    //permet de récupérer chaque item dans l'inventaire avec le nom nail
    public void Nails()
    {
       int i = 0;
        foreach (Item_Data item in inventory.content)
        {
            if (item.Item_Name == "nail")
            {
                i++;
                nails_in_inventory = i;
               
            }
        }
    }

    //permet de retirer le nombre de bois que coute la ressource après avoir appuyer sur le bouton craft
    void Wood_after_craft()
    {
        int compteur = 0;
        List<Item_Data> a_supprimer = new List<Item_Data>(); //stock les élément à supprimer dans une nouvelle liste pour éviter des bug lié à l'index
        for (int i = 0; i < inventory.content.Count; i++)
        {
            
            if (inventory.content[i].Item_Name == "Wooden Stick")
            {
                compteur++;
                a_supprimer.Add(inventory.content[i]);
                
            }
            if (compteur == bois_requis)
            {
                
                break;
            }
            
        }
        // on récupére tous ce qui est dans la lites a supprimer et on le supprime directement dans l'inventaire
        foreach (Item_Data item in  a_supprimer)
        {
            inventory.Remove_Item(item); 
        }
        
    }
    //permet de retirer le nombre de clou que coute la ressource après avoir appuyer sur le bouton craft
    void Nails_after_craft()
    {

        int compteur = 0;
        List<Item_Data> a_supprimer = new List<Item_Data>(); //stock les élément à supprimer dans une nouvelle liste pour éviter des bug lié à l'index
        for (int i = 0; i < inventory.content.Count; i++)
        {
            if (inventory.content[i].Item_Name == "nail")
            {
                compteur++;
                a_supprimer.Add(inventory.content[i]);

            }
            if (compteur == clou_requis)
            {
                
                break;
            }
           
        }
        // on récupére tous ce qui est dans la lites a supprimer et on le supprime directement dans l'inventaire
        foreach (Item_Data item in a_supprimer)
        {
            inventory.Remove_Item(item);
        }

    }

    //fonctoion qui permet de définir qu'est ce que l'on craft et avec quelles item !
    public void axe_button() 
    {

        bois.sprite = bois_sprite;
        clou.sprite = clou_sprite;
        craft_final.texture = axe;
        what_craft = 1;
        bois_requis = 5;
        clou_requis = 3;
        
    }
    //fonctoion qui permet de définir qu'est ce que l'on craft et avec quelles item !
    public void pitchforck_button() 
    {
        bois.sprite = bois_sprite;
        clou.sprite = clou_sprite;
        craft_final.texture = pitchfork;
        what_craft = 3;
        bois_requis = 7;
        clou_requis = 2;
    }

    //fonctoion qui permet de définir qu'est ce que l'on craft et avec quelles item !
    public void sickle_button() 
    {
        bois.sprite = bois_sprite;
        clou.sprite = clou_sprite;
        craft_final.texture = faussille;
        what_craft = 2;
        bois_requis = 5;
        clou_requis = 5;
    }
    //fonction qui calcule le nombre de bois et de clou restant dans l'inventaire 
    //appel les fonction pour supprimer le bon nombre de ressources
    public void craft_button()
    {
        weaponinstantiate.What_hand_craft();
        
        if ((wood_in_inventory >= bois_requis) && (nails_in_inventory >= clou_requis))
        {
            if ((wood_in_inventory - bois_requis) >= 0)
            {
                wood_in_inventory = wood_in_inventory - bois_requis;
            }

            if ((nails_in_inventory - clou_requis) >= 0)
            {
                nails_in_inventory = nails_in_inventory - clou_requis;
            }
           // hammer.Play();
            Wood_after_craft();
            Nails_after_craft();
        }
       
        
    }
}
