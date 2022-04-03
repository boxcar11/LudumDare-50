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
        GameObject panelImage = hintText.gameObject;
        if (panelImage != null)
        {
           panelImage.transform.parent.GetComponent<Image>().enabled = false;
        }
        hintText.enabled = false;
    }

    public virtual void Interact()
    {

    }
}
