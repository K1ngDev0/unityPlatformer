using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{   
    private void Update()
    {
        if(transform.eulerAngles.y == 180)
        {
            gameObject.GetComponent<SurfaceEffector2D>().speed = -1;
        }
        else if (transform.eulerAngles.y == 0)
        {
            gameObject.GetComponent<SurfaceEffector2D>().speed = 1;
        }
    }
}
