using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePlayer : MonoBehaviour
{

    public TMP_Text UpgradeCount;
    public TMP_Text UpgradeCost;
    public TMP_Text CurrentValue;

    private GameObject Player;
    private WaveModeScript PlayerCurrency;
    private PlayerCombat PlayerStats;

    private int UpgradeCountNum = 1;
    private int DamageUpgradeCost = 50;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerCurrency = Player.GetComponent<WaveModeScript>();
        PlayerStats = Player.GetComponent<PlayerCombat>();
        UpgradeCount.text = "" + UpgradeCountNum;
    }

    public void UpgradeDamage()
    {
        if (PlayerCurrency.money >= DamageUpgradeCost)
        {
            PlayerCurrency.money -= DamageUpgradeCost;
            DamageUpgradeCost += 10 * (UpgradeCountNum * 2);
            PlayerStats.damage += 10;
            UpgradeCountNum++;

            UpgradeCount.text = "" + UpgradeCountNum;
            UpgradeCost.text = "Cost: " + DamageUpgradeCost;
            CurrentValue.text = "Current Damage: " + PlayerStats.damage;
        }
        else
        {
            return;
        }
    }


}
