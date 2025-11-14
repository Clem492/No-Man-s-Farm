using UnityEngine;
using UnityEngine.UI;
public class craft : MonoBehaviour
{
    [SerializeField] Image bois;
    [SerializeField] Image clou;
    [SerializeField] RawImage craft_final;
    [SerializeField] TMPro.TextMeshProUGUI bois_text;
    [SerializeField] TMPro.TextMeshProUGUI clou_text;
    [SerializeField] Sprite bois_sprite;
   // [SerializeField] Sprite clou_sprite;
    [SerializeField] Texture axe;
    [SerializeField] Inventory inventory;
    int bois_requis;
    int i;
    int clou_requis;
    int wood_in_inventory;
    bool can_craft;


    private void Update()
    {
        bois_text.text = wood_in_inventory + "/" + bois_requis;
    }


    public void wood()
    {
        i = 0;
        foreach (Item_Data item in inventory.content)
        {
            if (item.Item_Name == "Wooden Stick")
            {
                i++;
                wood_in_inventory = i;
                if (i >= bois_requis)
                {
                    can_craft = true;
                }
            }
        }
    }
    public void axe_button()
    {
        Debug.Log("je suis bien appuyer");
        
        bois.sprite = bois_sprite;
       // clou.sprite = clou_sprite;
        craft_final.texture = axe;
        bois_requis = 5;
        
    }
}
