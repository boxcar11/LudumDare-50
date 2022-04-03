using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected InputManager inputManager;

    protected Inventory inventory;
    public SlotPanel slotPanel;

    public TMP_Text hintText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inputManager.SetInteractable(this);
        }
    }

    void OnTriggerExit2D()
    {
        inputManager.SetInteractable(null);
        hintText.gameObject.transform.parent.GetComponent<Image>().enabled = false;   
        hintText.enabled = false;
    }

    public virtual void Interact()
    {

    }
}
