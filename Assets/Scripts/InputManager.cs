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
    [SerializeField] private GameObject tooltip;

    [SerializeField] private Interactable interactable;

    private bool inventoryBool = false;
    private bool craftingBool = false;
    private bool menuBool = false;

    private float waitTime = 1;
    private float timer = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuBool = !menuBool;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryBool = !inventoryBool;

            if(inventoryBool == false)
            {
                TurnOffToolTip();
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            craftingBool = !craftingBool;

            if(craftingBool == false)
            {
                TurnOffToolTip();
            }
        }

        if (Input.GetButton("Action"))
        {
            if (interactable != null)
            {
                if (timer <= 0)
                {
                    DoAction();
                }
                timer -= Time.deltaTime;
            }
        }

        if (Input.GetButtonDown("Action"))
        {
            if(interactable != null)
            {
                DoAction();
            }
        }

        inventoryPanel.SetActive(inventoryBool);
        craftingPanel.SetActive(inventoryBool);
        craftedItemPanel.SetActive(inventoryBool);
        menuPanel.SetActive(menuBool);
    }

    void TurnOffToolTip()
    {
        tooltip.SetActive(false);
    }

    public void SetInteractable(Interactable i)
    {
        interactable = i;
    }

    private void DoAction()
    {
        interactable.Interact();
        timer = waitTime;
    }
}
