using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreeController : Interactable
{
    [SerializeField] private int treeHealth;

    private AudioSource audioSource;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        audioSource = GetComponent<AudioSource>();
        slotPanel = GameObject.Find("Holding Panel").GetComponent<SlotPanel>();
        hintText = GameObject.Find("Hint").GetComponent<TMP_Text>();  
        hintText.gameObject.transform.parent.GetComponent<Image>().enabled = false;   
        hintText.enabled = false;
    }

    public override void Interact()
    {
        int itemID = slotPanel.GetComponentInChildren<UIItem>().CheckForItem();
        if (itemID == 7)
        {
            hintText.transform.parent.GetComponent<Image>().enabled = false;
            hintText.enabled = false;
            treeHealth -= 1;

            audioSource.Play();

            if (treeHealth <= 0)
            {
                inventory.GiveItem("Wood");
                pickupSound.Play();
                Destroy(this.gameObject);
            }
        }
        else
        {
           hintText.transform.parent.GetComponent<Image>().enabled = true;
            hintText.enabled = true;
            hintText.text = "If only I had an Axe";
        }
    }
}
