using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherPad : MonoBehaviour
{
    public float launchForce = 10f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")

        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, launchForce);
        }
    }
}
