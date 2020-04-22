using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FoodItemData", menuName = "FoodItemData", order = 51)]
public class Food : InventoryItemData
{
    [SerializeField]
    private int calories = 0;
    [SerializeField]
    private int water = 0;

    public int Calories { get { return calories; } }
    public int Water { get { return water; } }
}
