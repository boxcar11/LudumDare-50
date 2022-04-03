using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFire : Interactable
{
    public GameObject campfirePrefab;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        inputManager = FindObjectOfType<InputManager>();
        slotPanel = GameObject.Find("Holding Panel").GetComponent<SlotPanel>();
    }

    public override void Interact()
    {
        Debug.Log("Interacting");
        // Holding campfire
        if (slotPanel.GetComponentInChildren<UIItem>().CheckForItem() == 12)
        {
            Debug.Log("Starting fire");
            Instantiate(campfirePrefab, this.transform.position, Quaternion.identity);
        }
    }
}
