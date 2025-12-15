using UnityEngine;

public class tabledecraft : MonoBehaviour
{
    public bool can_open_ui_craft;
    [SerializeField] Canvas craft_canva;
    [SerializeField] TMPro.TextMeshProUGUI text;

    private void Start()
    {
        can_open_ui_craft = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            can_open_ui_craft = true;
            
            text.text = "Press T to use";
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            text.text = "";
            can_open_ui_craft = false;
            craft_canva.enabled = false;
            
        }
           
    }
}
