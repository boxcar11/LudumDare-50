using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainController : Interactable
{
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        slotPanel = GameObject.Find("Holding Panel").GetComponent<SlotPanel>();
        hintText = GameObject.Find("Hint").GetComponent<TMP_Text>();
    }

    public override void Interact()
    {
        inventory.GiveItem("Scrap Metal");
        inventory.GiveItem("Wire");
        pickupSound.Play();
    }
}
