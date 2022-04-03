using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    
    public TMP_Text hintText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            inputManager.SetInteractable(this);
        }
    }

    void OnTriggerExit2D()
    {
        inputManager.SetInteractable(null);
        hintText.transform.parent.gameObject.SetActive(false);
    }

    public virtual void Interact()
    {

    }
}
