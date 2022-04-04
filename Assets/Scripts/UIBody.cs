using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBody : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private Inventory inventory;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        inventory = FindObjectOfType<Inventory>();
    }
    public void feedBody(Item item)
    {
        //Debug.Log(item.title);
        //Debug.Log("Feeding Body");
        if (item != null)
        {
            foreach (var stat in item.stats)
            {
                if (stat.Key == "Food")
                {
                    gameManager.AddFood(stat.Value);
                    GetComponentInParent<SlotPanel>().RemoveItem(item);
                }

                if (stat.Key == "Water")
                {
                    gameManager.AddWater(stat.Value);
                    GetComponentInParent<SlotPanel>().RemoveItem(item);
                    inventory.GiveItem(10);
                }
            }
        }
    }
}
