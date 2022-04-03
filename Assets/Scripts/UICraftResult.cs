using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICraftResult : MonoBehaviour
{
    public SlotPanel slotPanel;
    public Inventory inventory;

    public void  CollectCraftResult(Item craftedItem)
    {
        slotPanel.EmptyAllSlots();
        inventory.AddItem(craftedItem.id);
    }
}
