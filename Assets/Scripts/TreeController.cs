using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : Interactable
{
    [SerializeField] private int treeHealth;

    private Inventory inventory;
    private AudioSource audioSource;

    public SlotPanel slotPanel;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        int itemID = slotPanel.GetComponentInChildren<UIItem>().CheckForItem();
        Debug.Log(itemID);
        if (itemID == 7)
        {
            hintText.transform.parent.gameObject.SetActive(false);
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
            hintText.transform.parent.gameObject.SetActive(true);
            hintText.text = "If only I had an Axe";
        }
    }
}
