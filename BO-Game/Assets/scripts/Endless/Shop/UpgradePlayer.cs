using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePlayer : MonoBehaviour
{

    public TMP_Text UpgradeDamageCount, UpgradeDamageCost, CurrentDamage;
    public TMP_Text UpgradeMaxAmmoCount, UpgradeMaxAmmoCost, CurrentMaxAmmo;
    public TMP_Text UpgradeMaxHealthCount, UpgradeMaxHealthCost, CurrentMaxHealth;

    private GameObject Player;
    private WaveModeScript PlayerCurrency;
    private PlayerCombat PlayerStats;

    private int DamageUpgradeCountNum, MaxAmmoUpgradeCount, MaxHealthUpgradeCount = 1;
    private int DamageUpgradeCost, MaxAmmoUpgradeCost, MaxHealthUpgradeCost = 50;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerCurrency = Player.GetComponent<WaveModeScript>();
        PlayerStats = Player.GetComponent<PlayerCombat>();
    }

    public void UpgradeDamage()
    {
        if (PlayerCurrency.money >= DamageUpgradeCost) // if player has enough money
        {
            PlayerCurrency.money -= DamageUpgradeCost; // deducts price from money
            DamageUpgradeCost += 10 * (DamageUpgradeCountNum * 2); // calculates new price for upgrade
            PlayerStats.damage += 10; // upgrades stat
            DamageUpgradeCountNum++; // makes the level higher

            UpgradeDamageCount.text = "" + DamageUpgradeCountNum; // changes text on menu
            UpgradeDamageCost.text = "Cost: " + DamageUpgradeCost;
            CurrentDamage.text = "Current Damage: " + PlayerStats.damage;
        }
    }
    
    public void UpgradeMaxAmmo()
    {
        if (PlayerCurrency.money >= MaxAmmoUpgradeCost)
        {
            PlayerCurrency.money -= MaxAmmoUpgradeCost;
            MaxAmmoUpgradeCost += 10;
            PlayerStats.MaxAmmo += 50;
            MaxAmmoUpgradeCount++;

            UpgradeMaxAmmoCount.text = "" + MaxAmmoUpgradeCount;
            UpgradeMaxAmmoCost.text = "Cost: " + MaxAmmoUpgradeCost;
            CurrentMaxAmmo.text = "Current Max: " + PlayerStats.MaxAmmo;
        }
    }

    public void UpgradeMaxHealth()
    {
        if (PlayerCurrency.money >= MaxHealthUpgradeCost)
        {
            PlayerCurrency.money -= MaxHealthUpgradeCost;
            MaxHealthUpgradeCost += 10 * MaxHealthUpgradeCount;
            PlayerStats.MaxHealth += 25;
            MaxHealthUpgradeCount++;

            UpgradeMaxHealthCount.text = "" + MaxHealthUpgradeCount;
            UpgradeMaxHealthCost.text = "Cost: " + MaxHealthUpgradeCost;
            CurrentMaxHealth.text = "Current Max: " + PlayerStats.MaxHealth;
        }
    }
}
