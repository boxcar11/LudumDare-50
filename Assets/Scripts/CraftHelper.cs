using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftHelper : MonoBehaviour
{
    public SlotPanel slotPanel;
    public Image[] craftSlots;
    public Sprite[] sprites;

    void Start()
    {
        craftSlots[0] = slotPanel.transform.GetChild(0).GetComponent<Image>();
        craftSlots[1] = slotPanel.transform.GetChild(1).GetComponent<Image>();
        craftSlots[2] = slotPanel.transform.GetChild(2).GetComponent<Image>();
        craftSlots[3] = slotPanel.transform.GetChild(3).GetComponent<Image>();
        craftSlots[4] = slotPanel.transform.GetChild(4).GetComponent<Image>();
        craftSlots[5] = slotPanel.transform.GetChild(5).GetComponent<Image>();
        craftSlots[6] = slotPanel.transform.GetChild(6).GetComponent<Image>();
        craftSlots[7] = slotPanel.transform.GetChild(7).GetComponent<Image>();
        craftSlots[8] = slotPanel.transform.GetChild(8).GetComponent<Image>();
    }

    public void Campfire()
    {
        craftSlots[0].sprite = sprites[0];
        craftSlots[1].sprite = sprites[0];
        craftSlots[2].sprite = sprites[0];
        craftSlots[3].sprite = sprites[0];
        craftSlots[4].sprite = sprites[1];
        craftSlots[5].sprite = sprites[0];
        craftSlots[6].sprite = sprites[4];
        craftSlots[7].sprite = sprites[4];
        craftSlots[8].sprite = sprites[4];

    }

    public void Axe()
    {
        craftSlots[0].sprite = sprites[0];
        craftSlots[1].sprite = sprites[1];
        craftSlots[2].sprite = sprites[4];
        craftSlots[3].sprite = sprites[0];
        craftSlots[4].sprite = sprites[1];
        craftSlots[5].sprite = sprites[0];
        craftSlots[6].sprite = sprites[0];
        craftSlots[7].sprite = sprites[1];
        craftSlots[8].sprite = sprites[0];

    }

    public void Bucket()
    {
        craftSlots[0].sprite = sprites[0];
        craftSlots[1].sprite = sprites[0];
        craftSlots[2].sprite = sprites[0];
        craftSlots[3].sprite = sprites[2];
        craftSlots[4].sprite = sprites[0];
        craftSlots[5].sprite = sprites[2];
        craftSlots[6].sprite = sprites[2];
        craftSlots[7].sprite = sprites[2];
        craftSlots[8].sprite = sprites[2];
    }

    public void FishingPole()
    {
        craftSlots[0].sprite = sprites[0];
        craftSlots[1].sprite = sprites[0];
        craftSlots[2].sprite = sprites[2];
        craftSlots[3].sprite = sprites[0];
        craftSlots[4].sprite = sprites[4];
        craftSlots[5].sprite = sprites[0];
        craftSlots[6].sprite = sprites[0];
        craftSlots[7].sprite = sprites[4];
        craftSlots[8].sprite = sprites[0];
    }
}
