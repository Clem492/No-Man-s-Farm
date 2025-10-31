using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item_Data> content = new List<Item_Data>();
    public void Add_Item(Item_Data item)
    {
        content.Add(item);
    }

    [SerializeField] Canvas Inventory_ui;//Canva utiliser pour l'ui de l'inventaire
    [SerializeField] RawImage crosshaire;// r�cup�ration du crossaire pour le d�sactiver
    bool inventory_in_screen;//variable utiliser pour v�rifier si le canva est bien afficher a l'�cran
    //il faut que lorsque j'appuie sur une touche l'inventaire s'ouvre et se referme
    //il faut que mon viseur se d�sactive aussi 
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
    }

    IEnumerator cooldown_open_inventory()
    {
        yield return new WaitForSeconds(0.1f);
        inventory_in_screen = true;
    }

    IEnumerator cooldown_close_inventory()
    {
        yield return new WaitForSeconds(0.1f);
        inventory_in_screen = false;
    }
}
