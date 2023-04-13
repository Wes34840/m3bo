using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnShopItem : MonoBehaviour
{

    public WaveModeScript Player;
    public Transform SpawnPoint;
    public GameObject AmmoPickupPrefab;
    public int AmmoCost = 50;

    public TMP_Text CostText;

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
            CostText.text = "Cost: " + AmmoCost;
        }
        else
        {
            return;
        }
    }


}
