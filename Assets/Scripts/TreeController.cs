using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeController : Interactable
{
    [SerializeField] private int treeHealth;

    private AudioSource audioSource;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        audioSource = GetComponent<AudioSource>();
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
