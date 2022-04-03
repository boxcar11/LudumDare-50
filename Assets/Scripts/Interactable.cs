using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] InputManager inputManager;

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
    }

    public virtual void Interact()
    {

    }
}
