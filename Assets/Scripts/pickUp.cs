using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public GameObject pickupPivot;

    public GameObject collidersGameObject;

    bool isPickedUp = false;
    bool canPickUp = true;

    private void Update()
    {
        if (!GetComponent<BoxCollider2D>().isTrigger)
        {
            canPickUp = true;
        }
        else
        {
            canPickUp = false;
        }

        if (isPickedUp && canPickUp)
        {
            collidersGameObject.transform.position = pickupPivot.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Item")
        {
            Debug.Log("Picked up " + collision.name);
            collidersGameObject = collision.gameObject;
            isPickedUp = true;
        }
    }
    public void drop()
    {
        isPickedUp = false;
    }
}
