using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Awake()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string title)
    {
        return items.Find(item => item.title == title);
    }

    void BuildItemDatabase()
    {
        items = new List<Item>()
        {
            new Item(1, "Wood", "Stack of wood", new Dictionary<string, int>{{"Fuel", 15}}),
            new Item(2, "Cooked Meat", "Tastes like chicken", new Dictionary<string, int>{{"Food", 20}}),
            new Item(3, "Raw Rabbit", "Cook before eating", new Dictionary<string, int>()),
            new Item(4, "Berry", "Berry greatness", new Dictionary<string, int>{{"Food", 5}}),
            new Item(5, "Murky water", "Doesn't look good enough to drink", new Dictionary<string, int>()),
            new Item(6, "Water", "Clear fresh water", new Dictionary<string, int>{{"Water", 20}}),
            new Item(7, "Axe", "Careful sharp", new Dictionary<string, int>()),
            new Item(8, "Fishing Pole", "Here fishy fishy", new Dictionary<string, int>()),
            new Item(9, "Fish", "Eww it's slimey", new Dictionary<string, int>{{"Food", 5}}),
            new Item(10, "Bucket", "Holds fluid", new Dictionary<string, int>()),
            new Item(11, "Rock", "Very hard", new Dictionary<string, int>()),
            new Item(12, "Campfire", "Caution Hot", new Dictionary<string, int>()),
            new Item(13, "Wire", "Bendy", new Dictionary<string, int>()),
            new Item(14, "Scrap Metal", "Shiny", new Dictionary<string, int>())
        };
    }
}
