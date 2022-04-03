using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] string itemName;
    public Vector2 Wander()
    {
        return new Vector3(Random.Range(-100, 100), Random.Range(-100, 100),0);
    }

    public string GetItemName()
    {
        return itemName;
    }
}
