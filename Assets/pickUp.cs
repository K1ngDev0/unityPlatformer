using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public GameObject pickupPivot;
    GameObject player;

    bool isPickedUp = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isPickedUp)
        {
            player.transform.position = pickupPivot.transform.position;
        }
    }

    //pickup player on trigger entered
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPickedUp = true;
        }
    }
    public void drop()
    {
        isPickedUp = false;
    }
}
