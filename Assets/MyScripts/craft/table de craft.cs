using UnityEngine;

public class tabledecraft : MonoBehaviour
{
    public bool can_open_ui_craft;
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
            can_open_ui_craft = false;
            text.text = "";
        }
           
    }
}
