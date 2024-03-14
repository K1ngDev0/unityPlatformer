using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.GraphicsBuffer;

public class GrapplingHook : MonoBehaviour
{
    DistanceJoint2D rope;
    GameObject player;
    LineRenderer ropeRenderer;

    PlayerMovement playerMovement;

    [SerializeField] LayerMask groundLayer;

    public Vector2 mousePos;


    private void Start()
    {
        player = GameObject.Find("Player");
        ropeRenderer = gameObject.GetComponent<LineRenderer>();
        ropeRenderer.enabled = false;
        ropeRenderer.positionCount = 2;
        rope = gameObject.GetComponent<DistanceJoint2D>();
        rope.enabled = false;
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos, Mathf.Infinity, groundLayer);
            if (hit.collider != null)
            {
                playerMovement.enabled = false;
                ropeRenderer.enabled = true;
                rope.enabled = true;
                rope.connectedAnchor = mousePos;
                ropeRenderer.enabled = true;
                Debug.Log("Hit" + hit.collider.name);
            }
            else
            {
                Debug.Log("No hit");
            }
        }

        // Destroy rope
        else if (Input.GetMouseButtonUp(0))
        {
            rope.enabled = false;
            ropeRenderer.enabled = false;
            playerMovement.enabled = true;
        }
        if (rope != null && ropeRenderer.enabled)
        {
            ropeRenderer.SetPosition(0, transform.position);
            ropeRenderer.SetPosition(1, rope.connectedAnchor);
        }

    }


}