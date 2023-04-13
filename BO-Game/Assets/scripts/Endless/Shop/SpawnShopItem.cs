using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnShopItem : MonoBehaviour
{

    public WaveModeScript Player;
    public Transform SpawnPoint;
    public GameObject AmmoPickupPrefab, HealthPickupPrefab;
    public int AmmoCost = 50;
    public int HealthCost = 30;

    public TMP_Text AmmoCostText, HealthCostText;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<WaveModeScript>();
    }



    public void BuyAmmo()
    {
        if (Player.money >= AmmoCost)
        {
            Instantiate(AmmoPickupPrefab, SpawnPoint.position, Quaternion.identity);
            Player.money -= AmmoCost;
            AmmoCost += 10;
            AmmoCostText.text = "Cost: " + AmmoCost;
        }
    }

    public void BuyHealth()
    {
        if (Player.money >= HealthCost)
        {
            Instantiate(HealthPickupPrefab, SpawnPoint.position, Quaternion.identity);
            Player.money -= HealthCost;
            HealthCost += 10;
            HealthCostText.text = "Cost: " + HealthCost;
        }
    }

}
