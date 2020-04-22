using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InventoryItemData", menuName = "InventoryItemData", order = 51)]
public class InventoryItemData : ScriptableObject
{
    [SerializeField]
    private string itemName = "Item Name";
    [SerializeField]
    private string description = "No description";
    [SerializeField]
    private float weight = 1.0f;
    [SerializeField]
    private string path = "Prefabs/";
    [SerializeField]
    private Sprite icon = null;

    public string ItemName { get { return itemName; } }
    public string Description { get { return description; } }
    public float Weight { get { return weight; } }
    public string Path { get { return path; } }
    public Sprite Icon { get { return icon; } }
}
