using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ClothesItemData", menuName = "ClothesItemData", order = 51)]
public class Clothes : InventoryItemData
{
    [SerializeField]
    private float coldProtection = 0.0f;
    [SerializeField]
    private float windProtection = 0.0f;
    [System.Serializable]
    public enum bodyPartEnum
    {
        head,
        torsoInternal,
        torsoExternal,
        hands,
        legsInternal,
        legsExternal,
        feetInternal,
        feetExternal
    }
    [SerializeField]
    private bodyPartEnum bodyPart = bodyPartEnum.head;

    public float ColdProtection { get { return coldProtection; } }
    public float WindProtection { get { return windProtection; } }
    public bodyPartEnum BodyPart { get { return bodyPart; } }
}