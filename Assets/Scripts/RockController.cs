using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockController : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        inventory = FindObjectOfType<Inventory>();
        slotPanel = GameObject.Find("Holding Panel").GetComponent<SlotPanel>();
        hintText = GameObject.Find("Hint").GetComponent<TMP_Text>();  
        hintText.gameObject.transform.parent.GetComponent<Image>().enabled = false;   
        hintText.enabled = false;
    }

    public override void Interact()
    {
        inventory.GiveItem(11);
        Destroy(this.gameObject);
    }
}
