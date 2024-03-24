using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeAmount : MonoBehaviour
{
    public TextMeshProUGUI amountText;

    private void Update()
    {
        amountText.text = "" + GetComponent<RemoveSprite>().buildingAmount;
    }
}
