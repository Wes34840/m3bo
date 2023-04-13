using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveModeScript : MonoBehaviour
{

    public int money = 0;
    public TMP_Text MoneyField;

    private void Update()
    {
        MoneyField.text = "Money: " + money;
    }

}
