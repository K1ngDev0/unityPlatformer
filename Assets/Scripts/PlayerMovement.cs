using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpd = 5f;
    public float jumpForce = 5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private KeyCode jumpButton = KeyCode.Space;

    public bool doubleJump = true;

    private float coyoteTime = 0.2f;
    private float coyoteCounter;

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGrounded())
        {
            coyoteCounter = coyoteTime;
        }
        else
        {
            coyoteCounter -= Time.deltaTime;
        }

        if (isGrounded() && !Input.GetKey(jumpButton))
        {
            doubleJump = false;
        }

        if (Input.GetKeyDown(jumpButton))
        {
            if (coyoteCounter > 0f || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = !doubleJump;
            }
        }
        
        if (Input.GetKeyUp(jumpButton) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteCounter = 0f;
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(x * playerSpd, rb.velocity.y);
    }
}
