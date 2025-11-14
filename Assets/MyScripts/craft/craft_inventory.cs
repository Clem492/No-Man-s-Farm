using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class craft_inventory : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] Canvas craft_canva;
    public List<Image> slot_images_craft = new List<Image>();
    List<Item_Data> content;

    private void Start()
    {
        craft_canva.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        content = inventory.content;
        open_craft_pannel();
    }

    void open_craft_pannel()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            craft_canva.enabled = !craft_canva.enabled;
        }
    }

    public void Refresh_content()
    {
        //  Efface tous les slots d'abord
        foreach (var img in slot_images_craft)
        {
            img.sprite = null;

        }

        //  Puis affiche les items actuels dans l’ordre
        for (int i = 0; i < content.Count; i++)
        {
            slot_images_craft[i].sprite = content[i].Item_Image;

        }
    }
}
