using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBody : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void feedBody(Item item)
    {
        //Debug.Log(item.title);
        //Debug.Log("Feeding Body");
        foreach (var stat in item.stats)
        {
            if(stat.Key == "Food")
            {
                gameManager.AddFood(stat.Value);
                GetComponentInParent<SlotPanel>().RemoveItem(item);   
            }

            if(stat.Key == "Water")
            {
                gameManager.AddWater(stat.Value);
                GetComponentInParent<SlotPanel>().RemoveItem(item);
            }
        } 
    }
}
