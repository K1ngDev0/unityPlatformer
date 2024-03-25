using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 2.0f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item") || collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
