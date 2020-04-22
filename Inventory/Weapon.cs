using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponItemData", menuName = "WeaponItemData", order = 51)]
public class Weapon : InventoryItemData
{
    [SerializeField]
    private Vector3 position;
    [SerializeField]
    private Vector3 rotation;
    [SerializeField]
    private GameObject itemGameObject;

    public Vector3 Position { get { return position; } }
    public Vector3 Rotation { get { return rotation; } }
    public GameObject ItemGameObject { get { return itemGameObject; } }
}
