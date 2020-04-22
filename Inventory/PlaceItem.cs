using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlaceItemData", menuName = "PlaceItemData", order = 51)]
public class PlaceItem : InventoryItemData
{
    private GameObject itemGameObject;

    public GameObject ItemGameObject { get { return itemGameObject; } }
}
