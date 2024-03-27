using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class storeItems : MonoBehaviour
{
    public int amountOfItems = 0;
    public int totalItems = 10;

    public Transform outputPos;
    public List<GameObject> items = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        { 
            Debug.Log("Picked up " + collision.name);
            amountOfItems++;
            collision.gameObject.transform.position = outputPos.position;
            collision.gameObject.SetActive(false);
            items.Add(collision.gameObject);
        }
    }
}
