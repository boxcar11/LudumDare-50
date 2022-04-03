using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingController : Interactable
{
    private Inventory inventory;
    public Sprite fishLeft, fishRight, fishUp, fishDown;
    public Sprite fishEmote;
    public SpriteRenderer sr;
    public SpriteRenderer emote;

    public SlotPanel slotPanel;

    public int fishingPoleID;
    private bool fishing = false;
    private bool fishOnLine = false;
    private float castTimer;
    private float reelTimer = 5;


    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if (fishing)
        {
            castTimer -= Time.deltaTime;

            if (castTimer <= 0)
            {
                //Bobber move
                fishOnLine = true;
                emote.sprite = fishEmote;
                emote.gameObject.SetActive(true);
                reelTimer -= Time.deltaTime;

                if (reelTimer <= 0)
                {
                    fishing = false;
                    fishOnLine = false;
                    emote.gameObject.SetActive(false);
                    sr.GetComponent<Animator>().enabled = true;
                }
            }
        }
    }

    public override void Interact()
    {
        if (slotPanel.GetComponentInChildren<UIItem>().CheckForItem() == fishingPoleID)
        {
            if (fishing == false)
            {
                castTimer = Random.Range(2f, 10f);
                reelTimer = 5;
                fishing = true;
                //Cast line
                sr.GetComponent<Animator>().enabled = false;

                Vector3 direction = Vector3.Normalize(sr.transform.position - this.transform.position);
                float degree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                if (degree < 0)
                {
                    degree = 360 + degree;
                }
                Debug.Log(degree);
                float absoluteX = Mathf.Abs(direction.x);
                float absoluteY = Mathf.Abs(direction.y);

                if (degree < 300 && degree > 240)
                {
                    sr.sprite = fishUp;
                }
                else if (degree < 240 && degree > 120)
                {
                    sr.sprite = fishRight;
                }
                else if (degree < 120 && degree > 60)
                {
                    sr.sprite = fishDown;
                }
                else
                {
                    sr.sprite = fishLeft;
                }
            }
            else
            {
                //Reel in line
                if (fishOnLine)
                {
                    inventory.GiveItem("Berry");
                }

                fishOnLine = false;
                fishing = false;
                emote.gameObject.SetActive(false);

                sr.GetComponent<Animator>().enabled = true;
            }
        }
    }
}
