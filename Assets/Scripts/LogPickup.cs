using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogPickup : Interactable
{
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        slotPanel = GameObject.Find("Holding Panel").GetComponent<SlotPanel>();
        hintText = GameObject.Find("Hint").GetComponent<TMP_Text>();  
        hintText.gameObject.transform.parent.GetComponent<Image>().enabled = false;   
        hintText.enabled = false;
    }

    public override void Interact()
    {
        inventory.GiveItem("Wood");
        Destroy(this.gameObject);
    }
}
