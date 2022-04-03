using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> playerItems = new List<Item>();
    [SerializeField] private UIInventory inventoryUI;
    ItemDatabase itemDatabase;

    void Awake()
    {
        itemDatabase = FindObjectOfType<ItemDatabase>();
    }

    void Start()
    {
        GiveItem(1);
        GiveItem(3);
        GiveItem(5);
        GiveItem(7);
        GiveItem(8);
    }


    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        inventoryUI.AddItemToUI(itemToAdd);
        playerItems.Add(itemToAdd);
    }

    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        inventoryUI.AddItemToUI(itemToAdd);
        playerItems.Add(itemToAdd);
    }

    public Item CheckForItem(int id)
    {
        return playerItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);

        if(itemToRemove != null)
        {
            playerItems.Remove(itemToRemove);
        }
    }

    public void AddItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        playerItems.Add(itemToAdd);
    }
}
