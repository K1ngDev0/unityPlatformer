using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSprite : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (gameObject.GetComponent<BoxCollider2D>().isTrigger == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
            }
        }
    }
}
