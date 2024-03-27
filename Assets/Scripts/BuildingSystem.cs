using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class BuildingSystem : MonoBehaviour
{
    private GameObject buildingPrefabClone;
    public GameObject currentBuildingPrefab;
    public Sprite canBuildSprite;
    public Sprite cantBuildSprite;

    private GameObject player;
    
    GameObject clonesLocation;
    public float gridSize = 1f;

    private bool isPlacing = false;
    private bool keepBuilding = false;
    private bool isFlipped = false;

    public float playerReach = 5f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Awake()
    {
        clonesLocation = GameObject.FindGameObjectWithTag("buildingsParent");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isPlacing)
            {
                FlipSprite();
            }
        }

        if (isPlacing)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float snappedX = Mathf.Round(mousePosition.x / gridSize) * gridSize;
            float snappedY = Mathf.Round(mousePosition.y / gridSize) * gridSize;

            snappedX -= (currentBuildingPrefab.transform.localScale.x - 1) * gridSize / 2;
            snappedY -= (currentBuildingPrefab.transform.localScale.y - 1) * gridSize / 2;

            buildingPrefabClone.transform.position = new Vector2(snappedX, snappedY);

            buildingPrefabClone.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

            if (Vector2.Distance(player.transform.position, buildingPrefabClone.transform.position) <= playerReach)
            {
                buildingPrefabClone.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = canBuildSprite;

                if (IsBuildable() && buildingPrefabClone.GetComponent<RemoveSprite>().buildingAmount != 0)
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        keepBuilding = false;
                        build();
                    }
                    if (Input.GetMouseButton(0))
                    {
                        keepBuilding = true;

                        if (keepBuilding) build();
                    }
                }
                else if (!IsBuildable() || buildingPrefabClone.GetComponent<RemoveSprite>().buildingAmount == 0)
                {
                    buildingPrefabClone.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = cantBuildSprite;
                }
            }
            else if (Vector2.Distance(player.transform.position, buildingPrefabClone.transform.position) > playerReach)
            {
                buildingPrefabClone.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = cantBuildSprite;
            }

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(buildingPrefabClone);
                isPlacing = false;
            }

            
        }
    }

    private void FlipSprite()
    {
        if (buildingPrefabClone != null)
        {
            isFlipped = !isFlipped;

            buildingPrefabClone.transform.localScale = new Vector3(-buildingPrefabClone.transform.localScale.x, buildingPrefabClone.transform.localScale.y, buildingPrefabClone.transform.localScale.z);
        }
    }

    public void onButtonChoice(GameObject buildingPrefab)
    {
        Destroy(buildingPrefabClone);
        currentBuildingPrefab = buildingPrefab;
        createBuilding();
        isPlacing = true;
    }

    public void createBuilding()
    {
        buildingPrefabClone = Instantiate(currentBuildingPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        buildingPrefabClone.GetComponent<SpriteRenderer>().sortingOrder = 1;
        buildingPrefabClone.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
        buildingPrefabClone.GetComponent<BoxCollider2D>().isTrigger = true;
        buildingPrefabClone.name = currentBuildingPrefab.name;
        buildingPrefabClone.transform.parent = clonesLocation.transform;
    }

    public void build()
    {
        if (isPlacing)
        {
            buildingPrefabClone.layer = LayerMask.NameToLayer("Ground");
            buildingPrefabClone.GetComponent<SpriteRenderer>().sortingOrder = 0;
            buildingPrefabClone.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            buildingPrefabClone.GetComponent<BoxCollider2D>().isTrigger = false;
            buildingPrefabClone.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            currentBuildingPrefab.GetComponent<RemoveSprite>().buildingAmount = -1;
            createBuilding();
        }
    }   

    private bool IsBuildable()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(buildingPrefabClone.transform.position, Vector2.one * gridSize / 2 * buildingPrefabClone.transform.localScale, 0);

        foreach (Collider2D collider in colliders)
        {    
            if (collider.gameObject != buildingPrefabClone && !collider.isTrigger)
            {
                return false;
            }
        }
        return true;
    }
}
