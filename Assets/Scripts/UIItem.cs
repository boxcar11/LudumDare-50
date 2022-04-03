using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem;
    public bool craftingSlot = false;
    private CraftingSlots craftingSlots;
    private Tooltip tooltip;

    public bool craftedItemSlot = false;
    public bool bodyItemSlot = false;

    private void Awake()
    {
        craftingSlots = FindObjectOfType<CraftingSlots>();
        tooltip = FindObjectOfType<Tooltip>();
        selectedItem = GameObject.Find("Selected Item").GetComponent<UIItem>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
 
   }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if(this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item.icon;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
        if(craftingSlot)
        {
            craftingSlots.UpdateRecipe();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(this.item != null)
        {
            if(selectedItem.item != null && !craftedItemSlot && !bodyItemSlot)
            {
                Item clone = new Item(selectedItem.item);
                selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
            }
            else if(selectedItem.item == null)
            {
                selectedItem.UpdateItem(this.item);
                if(craftedItemSlot)
                {
                    GetComponent<UICraftResult>().CollectCraftResult(this.item);
                }
                
                UpdateItem(null);
            }
           
        }
        else if(selectedItem.item != null && !craftedItemSlot)
        {
            
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
            if(bodyItemSlot)
            {
                GetComponent<UIBody>().feedBody(this.item);
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.item != null)
        {
            tooltip.GenerateTooltip(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }

    public int CheckForItem()
    {
        return item.id;
    }
}
