using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSystem : MonoBehaviour
{
    public GameObject buildingPrefab;
    private GameObject buildingPrefabClone;
    
    GameObject clonesLocation;

    public float gridSize = 1f;

    [SerializeField] private bool isPlacing = false;

    private void Awake()
    {
        clonesLocation = new GameObject("Buildings");
    }

    private void Update()
    {
        if (isPlacing)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float snappedX = Mathf.Round(mousePosition.x / gridSize) * gridSize;
            float snappedY = Mathf.Round(mousePosition.y / gridSize) * gridSize;

            buildingPrefabClone.transform.position = new Vector2(snappedX, snappedY);

            if (Input.GetMouseButtonDown(0))
            {
                isPlacing = false;
            }
        }
    }

    public void onButtonChoice()
    {
        buildingPrefabClone = Instantiate(buildingPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        buildingPrefabClone.name = buildingPrefab.name;
        buildingPrefabClone.transform.parent = clonesLocation.transform;
        isPlacing = true;
    }    
}
