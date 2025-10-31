using UnityEngine;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class take_item : MonoBehaviour
{
    RaycastHit hit; //variable utiliser pour d�tecter les items dans le raycast
    [SerializeField] GameObject cam; //variable pour conna�tre l'origine et la direction du raycast
    [SerializeField] float ray_range; //variable pour d�terminer la meilleur distance du raycast

    [SerializeField] Inventory inventory;//variable utilise pour r�cup�rer la list de l'inventaire
    void pikup_item()
    {
        //cr�er un raycast capable de d�tecter les items
        //ajouter l'item a notre inventaire
        // supprmier l'object a la sc�ne
        Debug.DrawRay(cam.transform.position, cam.transform.forward * ray_range, Color.blue);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, ray_range))
        {
            if (hit.transform.CompareTag("item"))
            {
                Debug.Log("ceci est un item");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventory.Add_Item(hit.transform.GetComponent<Item>().item);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
       
    }
    private void Update()
    {
        pikup_item();
    }
}
