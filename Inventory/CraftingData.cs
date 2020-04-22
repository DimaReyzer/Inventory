using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CraftingData", menuName = "CraftingData", order = 51)]
public class CraftingData : ScriptableObject
{
    [System.Serializable]
    public struct itemStructure
    {
        public InventoryItem item;
        public int count;
    }
    [System.Serializable]
    public struct craftStructure{
        public itemStructure[] items;
        public InventoryItem craftedItem;
        public int count;
        public float waitTime;
    }

    public List<craftStructure> CraftItems;
}
