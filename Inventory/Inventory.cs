using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public struct itemStruct
    {
        public InventoryItem item;
        public int count;
        public float weight;
    }
    public List<itemStruct> items;
    public float weight;
    public float temperature;
    public float windProtection;
    public CraftingData craftingData;

    public InventoryItem head1;
    public InventoryItem head2;
    public InventoryItem torsoInternal1;
    public InventoryItem torsoInternal2;
    public InventoryItem torsoExternal;
    public InventoryItem hands;
    public InventoryItem legsInternal1;
    public InventoryItem legsInternal2;
    public InventoryItem legsExternal;
    public InventoryItem feetInternal1;
    public InventoryItem feetInternal2;
    public InventoryItem feetExternal;

    private CraftingUI craftingUI;
    private InventoryUI inventoryUI;
    private Player player;
    private EquipmentUI equipmentUI;
    private Hands handsWeapon;
    private MessageUI messageUI;

    void Start()
    {
        craftingUI = FindObjectOfType<CraftingUI>();
        inventoryUI = FindObjectOfType<InventoryUI>();
        equipmentUI = FindObjectOfType<EquipmentUI>();
        messageUI = FindObjectOfType<MessageUI>();
        handsWeapon = FindObjectOfType<Hands>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Inventory"))
        {
            if (inventoryUI.gameObject.activeSelf)
            {
                inventoryUI.gameObject.SetActive(false);
            }
            else
            {
                inventoryUI.gameObject.SetActive(true);
                if (craftingUI.gameObject.activeSelf)
                {
                    craftingUI.gameObject.SetActive(false);
                }
            }
        }
        if (Input.GetButtonUp("CraftingMenu"))
        {
            if (craftingUI.gameObject.activeSelf)
            {
                craftingUI.gameObject.SetActive(false);
            }
            else
            {
                craftingUI.gameObject.SetActive(true);
                if (inventoryUI.gameObject.activeSelf)
                {
                    inventoryUI.gameObject.SetActive(false);
                }
            }
        }
    }

    public void AddItem(InventoryItemData item)
    {
        itemStruct localItem = new itemStruct();
        if(items.Count != 0)
        {
            for(int i = 0;i < items.Count; i++)
            {
                if(items[i].item.inventoryItemData.Path == item.Path)
                {
                    localItem = items[i];
                    localItem.count++;
                    localItem.weight = item.Weight * localItem.count;
                    items[i] = localItem;
                    break;
                }
                else if(i + 1 == items.Count)
                {
                    if (Resources.Load<InventoryItem>(item.Path) != null)
                    {
                        localItem.item = Resources.Load<InventoryItem>(item.Path);
                        localItem.count = 1;
                        localItem.weight = item.Weight;
                        items.Add(localItem);
                        break;
                    }
                    else
                    {
                        Debug.LogError("Item does not founded");
                    }
                }
            }
        }
        else
        {
            if (Resources.Load<InventoryItem>(item.Path) != null)
            {
                localItem.item = Resources.Load<InventoryItem>(item.Path);
                localItem.count = 1;
                localItem.weight = item.Weight;
                items.Add(localItem);
            }
            else
            {
                Debug.LogError("Item does not founded");
            }
        }
        CalculateInventory();
    }
    public void RemoveItem(int index)
    {
        itemStruct localItemStruct;
        if (items[index].count > 1)
        {
            localItemStruct = items[index];
            localItemStruct.count--;
            localItemStruct.weight = items[index].item.inventoryItemData.Weight * localItemStruct.count;
            items[index] = localItemStruct;
        }
        else
        {
            localItemStruct = items[index];
            items.Remove(localItemStruct);
        }
        CalculateInventory();
    }
    public void CalculateInventory()
    {
        weight = 0;
        temperature = 0;
        windProtection = 0;
        for(int i = 0;i < items.Count; i++)
        {
            weight += items[i].weight;
        }
        Clothes getHead1 = null;
        Clothes getHead2 = null;
        Clothes getTorsoInternal1 = null;
        Clothes getTorsoInternal2 = null;
        Clothes getTorsoExternal = null;
        Clothes getHands = null;
        Clothes getLegsInternal1 = null;
        Clothes getLegsInternal2 = null;
        Clothes getLegsExternal = null;
        Clothes getFeetInternal1 = null;
        Clothes getFeetInternal2 = null;
        Clothes getFeetExternal = null;
        if (head1 != null)
        {
            getHead1 = head1.inventoryItemData as Clothes;
            temperature += getHead1.ColdProtection;
            windProtection += getHead1.WindProtection;
        }
        if (head2 != null)
        {
            getHead2 = head2.inventoryItemData as Clothes;
            temperature += getHead2.ColdProtection;
            windProtection += getHead2.WindProtection;
        }
        if (torsoInternal1 != null)
        {
            getTorsoInternal1 = torsoInternal1.inventoryItemData as Clothes;
            temperature += getTorsoInternal1.ColdProtection;
            windProtection += getTorsoInternal1.WindProtection;
        }
        if (torsoInternal2 != null)
        {
            getTorsoInternal2 = torsoInternal2.inventoryItemData as Clothes;
            temperature += getTorsoInternal2.ColdProtection;
            windProtection += getTorsoInternal2.WindProtection;
        }
        if (torsoExternal != null)
        {
            getTorsoExternal = torsoExternal.inventoryItemData as Clothes;
            temperature += getTorsoExternal.ColdProtection;
            windProtection += getTorsoExternal.WindProtection;
        }
        if (hands != null)
        {
            getHands = hands.inventoryItemData as Clothes;
            temperature += getHands.ColdProtection;
            windProtection += getHands.WindProtection;
        }
        if (legsInternal1 != null)
        {
            getLegsInternal1 = legsInternal1.inventoryItemData as Clothes;
            temperature += getLegsInternal1.ColdProtection;
            windProtection += getLegsInternal1.WindProtection;
        }
        if (legsInternal2 != null)
        {
            getLegsInternal2 = legsInternal2.inventoryItemData as Clothes;
            temperature += getLegsInternal2.ColdProtection;
            windProtection += getLegsInternal2.WindProtection;
        }
        if (legsExternal != null)
        {
            getLegsExternal = legsExternal.inventoryItemData as Clothes;
            temperature += getLegsExternal.ColdProtection;
            windProtection += getLegsExternal.WindProtection;
        }
        if (feetInternal1 != null)
        {
            getFeetInternal1 = feetInternal1.inventoryItemData as Clothes;
            temperature += getFeetInternal1.ColdProtection;
            windProtection += getFeetInternal1.WindProtection;
        }
        if (feetInternal2 != null)
        {
            getFeetInternal2 = feetInternal2.inventoryItemData as Clothes;
            temperature += getFeetInternal2.ColdProtection;
            windProtection += getFeetInternal2.WindProtection;
        }
        if (feetExternal != null)
        {
            getFeetExternal = feetExternal.inventoryItemData as Clothes;
            temperature += getFeetExternal.ColdProtection;
            windProtection += getFeetExternal.WindProtection;
        }
        equipmentUI.UpdateClothes();
        inventoryUI.UpdateInventory();
    }
    public int FindItemIndex(InventoryItem item)
    {
        int localInt = -1;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item == item)
            {
                localInt = i;
            }
        }
        return localInt;
    }
    public int FindItemNameIndex(string name)
    {
        int localInt = -1;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item.inventoryItemData.ItemName == name)
            {
                localInt = i;
            }
        }
        return localInt;
    }
    public void Consume(int index)
    {
        Food getFood = items[index].item.inventoryItemData as Food;
        if (getFood != null)
        {
            player.waitTime += 5;
            player.food += getFood.Calories;
            player.water += getFood.Water;
            RemoveItem(index);
        }
    }
    public void EquipWeapon(int index)
    {
        Weapon getWeapon = items[index].item.inventoryItemData as Weapon;
        if (getWeapon != null)
        {
            handsWeapon.EquipItem(Resources.Load<InventoryItem>(getWeapon.Path));
        }
    }
    public void EquipClothes(int index)
    {
        Clothes getClothes = items[index].item.inventoryItemData as Clothes;
        if(getClothes != null)
        {
            if(getClothes.BodyPart == Clothes.bodyPartEnum.head)
            {
                if(head1 != null)
                {
                    if(head2 != null)
                    {
                        RemoveHead2();
                        head2 = items[index].item;
                        RemoveItem(index);
                    }
                    else
                    {
                        head2 = items[index].item;
                        RemoveItem(index);
                    }
                }
                else
                {
                    head1 = items[index].item;
                    RemoveItem(index);
                }
            }
            else if(getClothes.BodyPart == Clothes.bodyPartEnum.torsoInternal)
            {
                if (torsoInternal1 != null)
                {
                    if (torsoInternal2 != null)
                    {
                        RemoveTorsoInternal2();
                        torsoInternal2 = items[index].item;
                        RemoveItem(index);
                    }
                    else
                    {
                        torsoInternal2 = items[index].item;
                        RemoveItem(index);
                    }
                }
                else
                {
                    torsoInternal1 = items[index].item;
                    RemoveItem(index);
                }
            }
            else if (getClothes.BodyPart == Clothes.bodyPartEnum.torsoExternal)
            {
                if (torsoExternal != null)
                {
                    RemoveTorsoExternal();
                    torsoExternal = items[index].item;
                    RemoveItem(index);
                }
                else
                {
                    torsoExternal = items[index].item;
                    RemoveItem(index);
                }
            }
            else if (getClothes.BodyPart == Clothes.bodyPartEnum.hands)
            {
                if (hands != null)
                {
                    RemoveHands();
                    hands = items[index].item;
                    RemoveItem(index);
                }
                else
                {
                    hands = items[index].item;
                    RemoveItem(index);
                }
            }
            else if (getClothes.BodyPart == Clothes.bodyPartEnum.legsExternal)
            {
                if (legsExternal != null)
                {
                    RemoveLegsExternal();
                    legsExternal = items[index].item;
                    RemoveItem(index);
                }
                else
                {
                    legsExternal = items[index].item;
                    RemoveItem(index);
                }
            }
            else if (getClothes.BodyPart == Clothes.bodyPartEnum.legsInternal)
            {
                if (legsInternal1 != null)
                {
                    if (legsInternal2 != null)
                    {
                        RemoveLegsInternal2();
                        legsInternal2 = items[index].item;
                        RemoveItem(index);
                    }
                    else
                    {
                        legsInternal2 = items[index].item;
                        RemoveItem(index);
                    }
                }
                else
                {
                    legsInternal1 = items[index].item;
                    RemoveItem(index);
                }
            }
            else if (getClothes.BodyPart == Clothes.bodyPartEnum.feetInternal)
            {
                if (feetInternal1 != null)
                {
                    if (feetInternal2 != null)
                    {
                        RemoveFeetInternal2();
                        feetInternal2 = items[index].item;
                        RemoveItem(index);
                    }
                    else
                    {
                        feetInternal2 = items[index].item;
                        RemoveItem(index);
                    }
                }
                else
                {
                    feetInternal1 = items[index].item;
                    RemoveItem(index);
                }
            }
            else if (getClothes.BodyPart == Clothes.bodyPartEnum.feetExternal)
            {
                if (feetExternal != null)
                {
                    RemoveFeetExternal();
                    feetExternal = items[index].item;
                    RemoveItem(index);
                }
                else
                {
                    feetExternal = items[index].item;
                    RemoveItem(index);
                }
            }
        }
        CalculateInventory();
    }
    public void RemoveHead1()
    {
        AddItem(head1.inventoryItemData);
        head1 = null;
        CalculateInventory();
    }
    public void RemoveHead2()
    {
        AddItem(head2.inventoryItemData);
        head2 = null;
        CalculateInventory();
    }
    public void RemoveTorsoInternal1()
    {
        AddItem(torsoInternal1.inventoryItemData);
        torsoInternal1 = null;
        CalculateInventory();
    }
    public void RemoveTorsoInternal2()
    {
        AddItem(torsoInternal2.inventoryItemData);
        torsoInternal2 = null;
        CalculateInventory();
    }
    public void RemoveTorsoExternal()
    {
        AddItem(torsoExternal.inventoryItemData);
        torsoExternal = null;
        CalculateInventory();
    }
    public void RemoveHands()
    {
        AddItem(hands.inventoryItemData);
        hands = null;
        CalculateInventory();
    }
    public void RemoveLegsExternal()
    {
        AddItem(legsExternal.inventoryItemData);
        legsExternal = null;
        CalculateInventory();
    }
    public void RemoveLegsInternal1()
    {
        AddItem(legsInternal1.inventoryItemData);
        legsInternal1 = null;
        CalculateInventory();
    }
    public void RemoveLegsInternal2()
    {
        AddItem(legsInternal2.inventoryItemData);
        legsInternal2 = null;
        CalculateInventory();
    }
    public void RemoveFeetExternal()
    {
        AddItem(feetExternal.inventoryItemData);
        feetExternal = null;
        CalculateInventory();
    }
    public void RemoveFeetInternal1()
    {
        AddItem(feetInternal1.inventoryItemData);
        feetInternal1 = null;
        CalculateInventory();
    }
    public void RemoveFeetInternal2()
    {
        AddItem(feetInternal2.inventoryItemData);
        feetInternal2 = null;
        CalculateInventory();
    }
    public void CedeToContainer(Container container, int index)
    {
        if(index < items.Count)
        {
            container.AddItem(items[index].item.inventoryItemData);
            RemoveItem(index);
        }
    }
    public void DropItem(int index)
    {
        if (index < items.Count)
        {
            InventoryItem instItem = Instantiate<InventoryItem>(items[index].item);
            RaycastHit downhit;
            if (Physics.Raycast(transform.position, Vector3.down, out downhit))
            {
                instItem.transform.position = downhit.point;
            }
            RemoveItem(index);
        }
    }
    public void PlaceItem(int index)
    {
        if (index < items.Count)
        {
            RaycastHit downhit;
            if (Physics.Raycast(transform.position, Vector3.down, out downhit) && downhit.collider.gameObject.layer != 10)
            {
                if (items[index].item.inventoryItemData.ItemName != "Ice hole")
                {
                    if (downhit.collider.GetComponent<UsableObject>() == null)
                    {
                        InventoryItem instItem = Instantiate<InventoryItem>(items[index].item);
                        instItem.transform.position = downhit.point;
                        Destroy(instItem.GetComponent<InventoryItem>());
                        RemoveItem(index);
                    }
                }
                else
                {
                    InventoryItem instItem = Instantiate<InventoryItem>(items[index].item);
                    instItem.transform.position = downhit.point;
                    Destroy(instItem.GetComponent<InventoryItem>());
                    RemoveItem(index);
                }
            }
            else
            {
                messageUI.Message("You can't put this in a building!");
            }
        }
    }
    public void CraftItem(int index)
    {
        if(index < craftingData.CraftItems.Count)
        {
            for(int a = 0;a < craftingData.CraftItems[index].items.Length; a++)
            {
                if (FindItemIndex(craftingData.CraftItems[index].items[a].item) != -1)
                {
                    if (items[FindItemIndex(craftingData.CraftItems[index].items[a].item)].count >= craftingData.CraftItems[index].items[a].count)
                    {
                        if (a + 1 == craftingData.CraftItems[index].items.Length)
                        {
                            for (int b = 0; b < craftingData.CraftItems[index].items.Length; b++)
                            {
                                if (craftingData.CraftItems[index].items[b].count != 0)
                                {
                                    for (int c = 0; c < craftingData.CraftItems[index].items[b].count; c++)
                                    {
                                        RemoveItem(FindItemIndex(craftingData.CraftItems[index].items[b].item));
                                    }
                                }
                            }
                            for (int d = 0; d < craftingData.CraftItems[index].count; d++)
                            {
                                AddItem(craftingData.CraftItems[index].craftedItem.inventoryItemData);
                            }
                            player.waitTime += craftingData.CraftItems[index].waitTime;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
