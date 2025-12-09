using UnityEngine;


public class take_item : MonoBehaviour
{
    RaycastHit hit; //variable utiliser pour détecter les items dans le raycast
    [SerializeField] GameObject cam; //variable pour connaître l'origine et la direction du raycast
    [SerializeField] float ray_range; //variable pour déterminer la meilleur distance du raycast

    [SerializeField] Inventory inventory;//variable utilise pour récupérer la list de l'inventaire
    void pikup_item()
    {
        //créer un raycast capable de détecter les items
        //ajouter l'item a notre inventaire
        // supprmier l'object a la scène
        Debug.DrawRay(cam.transform.position, cam.transform.forward * ray_range, Color.blue);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, ray_range))
        {
            if (hit.transform.CompareTag("item") || hit.transform.CompareTag("arme"))
            {
             
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (inventory.Inventory_Full())
                    {
                        return;
                    }

                    inventory.Add_Item(hit.transform.GetComponent<Item>().item);
                    Destroy(hit.transform.gameObject);
                    inventory.GetComponent<Inventory>().Refresh_content();
                }
            }
        }
       
    }

 
    private void Update()
    {
        pikup_item();
    }
}
