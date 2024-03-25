using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class toolSystem : MonoBehaviour
{
    [SerializeField] GameObject buildingMenu;
    public bool menuActive = false;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {

            if (!menuActive)
            {
                buildingMenu.transform.position = new Vector3(0, 0, 0);
                menuActive = true;
            }
            else if (menuActive)
            {
                buildingMenu.transform.position = new Vector3(0, 30, 0);
                menuActive = false;
            }
        }
    }
}
