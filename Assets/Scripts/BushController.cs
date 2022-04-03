using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushController : Interactable
{
    public Sprite bush;
    public Sprite berryBush;

    public SpriteRenderer spriteRenderer;
    private bool pickable = true;
    private float timer;
    [SerializeField] float pickableTime = 60;
    private Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if(pickable == false)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            pickable = true;
            spriteRenderer.sprite = berryBush;
        }
    }

    public override void Interact()
    {
        if(pickable)
        {
            int numberOfBerries = Random.Range(1,3);
            for (int i = 0; i < numberOfBerries; i++)
            {
                inventory.GiveItem("Berry");
            }

            pickable = false;
            spriteRenderer.sprite = bush;
            timer = pickableTime;
        }
    }
}
