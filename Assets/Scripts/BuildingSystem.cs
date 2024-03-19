using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{
    public GameObject buildingPrefab;
    private GameObject buildingPrefabClone;
    
    GameObject clonesLocation;

    SpriteRenderer buildingPrefabSprite;
    [SerializeField] Image UIBuilding;

    public float gridSize = 1f;

    [SerializeField] private bool isPlacing = false;

    private void Start()
    {
        UIBuilding = UIBuilding.GetComponent<Image>();
        buildingPrefabSprite = buildingPrefab.GetComponent<SpriteRenderer>();
        UIBuilding.sprite = buildingPrefabSprite.sprite;
    }

    private void Awake()
    {
        clonesLocation = GameObject.FindGameObjectWithTag("buildingsParent");
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
        if (!isPlacing)
        {
            buildingPrefabClone = Instantiate(buildingPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            buildingPrefabClone.name = buildingPrefab.name;
            buildingPrefabClone.transform.parent = clonesLocation.transform;
            isPlacing = true;
        }
    }    
}
