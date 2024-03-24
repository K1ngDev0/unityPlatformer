using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RemoveSprite : MonoBehaviour
{
    private GameObject buildingSystem;
    private GameObject player;

    public int buildingAmount;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        buildingSystem = GameObject.FindGameObjectWithTag("BuildingSystem");
    }

    private void OnMouseOver()
    {
        if (gameObject.GetComponent<BoxCollider2D>().isTrigger == false)
        {
            if (Vector2.Distance(player.transform.position, transform.position) <= buildingSystem.GetComponent<BuildingSystem>().playerReach)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Destroy(gameObject);
                }
            }   
        }
    }
}
