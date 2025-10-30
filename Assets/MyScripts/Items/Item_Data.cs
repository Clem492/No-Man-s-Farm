using UnityEngine;

[CreateAssetMenu(fileName = "Item_Data", menuName = "Items/New Items")]
public class Item_Data : ScriptableObject
{
    public string Item_Name;
    public string Item_Description;
    public GameObject Prefab;
    public int Quantity;
    public int Stack;
    public int Durability;
}
