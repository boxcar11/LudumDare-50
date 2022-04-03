using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPanel : MonoBehaviour
{
    public List<UIItem> uIItems = new List<UIItem>();
    public int numberOfSlots;
    public GameObject slotPrefab;

    public Inventory inventory;

    void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(transform);
            uIItems.Add(instance.GetComponentInChildren<UIItem>());
            uIItems[i].item = null;
        }
    }

    void UpdateSlot(int slot, Item item)
    {
        uIItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == item), null);
    }

    public void EmptyAllSlots()
    {
        uIItems.ForEach(i =>
        {
            if(i.item != null)
            {
                inventory.RemoveItem(i.item.id);
            }

            i.UpdateItem(null);
        });
    }

    public bool ContainsEmptySlot()
    {
        foreach(UIItem uii in uIItems)
        {
            if(uii.item == null) return true;
        }
        return false;
    }
}
