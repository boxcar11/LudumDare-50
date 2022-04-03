using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : Interactable
{
    [SerializeField] private int treeHealth;

    private Inventory inventory;
    private AudioSource audioSource;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        treeHealth -= 1;

        audioSource.Play();

        if(treeHealth <= 0)
        {
            inventory.GiveItem("Wood");
            Destroy(this.gameObject);
        }
    }
}
