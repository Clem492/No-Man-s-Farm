using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item_Data> content = new List<Item_Data>();
    public void Add_Item(Item_Data item)
    {
        content.Add(item);
    }
}
