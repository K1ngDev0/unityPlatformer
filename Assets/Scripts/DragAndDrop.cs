using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    public GameObject buildingPrefab;

    Vector2 difference = Vector2.zero;
    public float gridSize = 1f;

    [SerializeField] private bool isPlacing = false;

    private void Update()
    {
       

        if (isPlacing)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float snappedX = Mathf.Round(mousePosition.x / gridSize) * gridSize;
            float snappedY = Mathf.Round(mousePosition.y / gridSize) * gridSize;

            buildingPrefab.transform.position = new Vector2(snappedX, snappedY);

            if (Input.GetMouseButtonDown(0))
            {
                isPlacing = false;
            }
        }
    }

    public void onButtonChoice()
    {
        buildingPrefab = Instantiate(buildingPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        isPlacing = true;
    }
        
}
