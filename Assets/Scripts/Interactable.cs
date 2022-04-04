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

    public AudioSource pickupSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Triggering");
            inputManager.SetInteractable(this);
            hintText.gameObject.transform.parent.GetComponent<Image>().enabled = true;
            hintText.enabled = true;
            hintText.text = "E";
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
