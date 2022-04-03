using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : AnimalController
{
    Vector3 wanderPoint;

    [SerializeField] float moveSpeed;

    private bool chasePlayer;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        wanderPoint = Wander();
    }

    void Update()
    {
        if (chasePlayer)
        {
            wanderPoint = player.transform.position;
        }

        if(this.transform.position.x - wanderPoint.x < 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }

        transform.position = Vector3.MoveTowards(this.transform.position, wanderPoint, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, wanderPoint) < 0.001f)
        {
            wanderPoint = Wander();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            chasePlayer = true;
            player = collider.gameObject;
        }
    }

    void OnTriggerExit2D()
    {
        wanderPoint = Wander();
        chasePlayer = false;
    }
}
