using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Inventory inventory;
    GameManager gameManager;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        GetComponentInChildren<Animator>().SetFloat("MoveX", horizontal);
        GetComponentInChildren<Animator>().SetFloat("MoveY", vertical);

        Vector2 direction = new Vector2(horizontal, vertical);
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Animal")
        {
            inventory.GiveItem(other.gameObject.GetComponent<AnimalController>().GetItemName());
            //Debug.Log("Collided with animal");
            Destroy(other.gameObject);
        }
    }
}
