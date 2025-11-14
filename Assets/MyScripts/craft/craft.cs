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
    [SerializeField] Sprite clou_sprite;
    [SerializeField] Texture axe;
    [SerializeField] Texture pitchfork;
    [SerializeField] Texture faussille;
    [SerializeField] Inventory inventory;
    [SerializeField] weaponinstantiate weaponinstantiate;
    public int bois_requis;
    public int clou_requis;
    public int wood_in_inventory;
    public int nails_in_inventory;
    public int what_craft;
    bool can_craft;

    private void Start()
    {
        what_craft = 1;
        bois.sprite = bois_sprite;
        clou.sprite = clou_sprite;
        craft_final.texture = axe;
        bois_requis = 5;
        clou_requis = 5;
    }

    private void Update()
    {
        bois_text.text = wood_in_inventory + "/" + bois_requis;
        clou_text.text = nails_in_inventory +"/" + clou_requis;
    }


    public void Wood()
    {
       int i = 0;
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

    public void Nails()
    {
       int i = 0;
        foreach (Item_Data item in inventory.content)
        {
            if (item.Item_Name == "nail")
            {
                i++;
                nails_in_inventory = i;
                if (i >= clou_requis)
                {
                    can_craft = true;
                }
            }
        }
    }

    void Wood_after_craft()
    {

    }
    public void axe_button()
    {

        bois.sprite = bois_sprite;
        clou.sprite = clou_sprite;
        craft_final.texture = axe;
        what_craft = 1;
        bois_requis = 5;
        clou_requis = 5;
        
    }

    public void pitchforck_button()
    {
        bois.sprite = bois_sprite;
        clou.sprite = clou_sprite;
        craft_final.texture = pitchfork;
        what_craft = 3;
        bois_requis = 7;
        clou_requis = 2;
    }

    public void sickle_button()
    {
        bois.sprite = bois_sprite;
        clou.sprite = clou_sprite;
        craft_final.texture = faussille;
        what_craft = 2;
        bois_requis = 5;
        clou_requis = 5;
    }

    public void craft_button()
    {
        weaponinstantiate.What_hand_craft();
        wood_in_inventory =wood_in_inventory - bois_requis;
        nails_in_inventory = nails_in_inventory - clou_requis;

    }
}
