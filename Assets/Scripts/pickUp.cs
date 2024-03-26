using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public GameObject pickupPivot;

    public GameObject collidersGameObject;

    Animator anim;

    bool isPickedUp = false;
    bool canPickUp = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.enabled = true;
    }

    public void drop()
    {
        isPickedUp = false;
    }

    public void onAnimationEnd()
    {
        anim.enabled = false;
    }
}
