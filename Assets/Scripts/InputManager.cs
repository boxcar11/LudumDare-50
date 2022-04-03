using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject craftingPanel;
    [SerializeField] private GameObject craftedItemPanel;
    [SerializeField] private GameObject bodyPanel;
    [SerializeField] private GameObject menuPanel;

    Interactable interactable; 

    private bool inventoryBool = false;
    private bool craftingBool = false;
    private bool menuBool = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menuBool = !menuBool;
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryBool = !inventoryBool;
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            craftingBool = !craftingBool;
        }

        if(Input.GetButtonDown("Action"))
        {
            if(interactable != null)
            {
            interactable.Interact();
            }
        }

        inventoryPanel.SetActive(inventoryBool);
        bodyPanel.SetActive(inventoryBool);
        craftingPanel.SetActive(craftingBool);
        craftedItemPanel.SetActive(craftingBool);
        menuPanel.SetActive(menuBool);
    }

    public void SetInteractable(Interactable i)
    {
        interactable = i;
    }
}
