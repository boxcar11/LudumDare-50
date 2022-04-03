using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FireController : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        inputManager = FindObjectOfType<InputManager>();
        slotPanel = GameObject.Find("Holding Panel").GetComponent<SlotPanel>();
        hintText = GameObject.Find("Hint").GetComponent<TMP_Text>();      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        // Holding raw meat
        if (slotPanel.GetComponentInChildren<UIItem>().CheckForItem() == 3)
        {
            inventory.GiveItem(2);
            slotPanel.EmptyAllSlots();
        }
        // Holding murky water
        else if (slotPanel.GetComponentInChildren<UIItem>().CheckForItem() == 5)
        {
            inventory.GiveItem(6);
            slotPanel.EmptyAllSlots();
        }
        else
        {
            hintText.transform.parent.GetComponent<Image>().enabled = true;
            hintText.enabled = true;
            hintText.text = "I bet I can cook here";
        }
    }
}
