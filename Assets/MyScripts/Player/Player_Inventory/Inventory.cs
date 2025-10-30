using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class Items
{
    public string Items_name;
    [SerializeField] int max_Stack;
    public int quantity;
}



public class Inventory : MonoBehaviour
{
   [SerializeField] GameObject cam;
    RaycastHit hit;
    public List<Items> items;




    void raycast_item()
    {
        
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 4.5f, Color.cyan);

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit , 4.5f))
        {
                Debug.Log("tu peux prendre cette object !");
        }
    }

    private void Update()
    {
        raycast_item();
    }


}
