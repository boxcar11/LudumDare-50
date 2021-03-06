using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : AnimalController
{
    Vector3 wanderPoint;

    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        wanderPoint = Wander();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x - wanderPoint.x < 0)
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
}
