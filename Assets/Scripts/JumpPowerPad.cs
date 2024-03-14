using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerPad : MonoBehaviour
{
    public float extraJumpForce = 10f;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")

        {
            collision.GetComponent<PlayerMovement>().jumpForce += extraJumpForce;
        }
    }
}
