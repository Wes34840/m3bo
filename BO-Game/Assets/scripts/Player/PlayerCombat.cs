using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerCombat: MonoBehaviour
{
    public int health, MaxHealth = 200;
    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffectBlood;
    public GameObject impactEffectSpark;
    public HealthUpdate healthUpdate;
    public int ammo = 30;
    public int MaxAmmo = 200;
    public int score = 0;

    public PlayerMovement player;
    internal PlayerAudioPlayer playerAudioPlayer;

    private void Start()
    {
        player= GetComponent<PlayerMovement>();
        playerAudioPlayer = GetComponent<PlayerAudioPlayer>();
    }

    private void Shoot() // Shooting logic
    {
        playerAudioPlayer.PlayAudio(AudioClips.Shoot);

        RaycastHit2D Hit = Physics2D.Raycast(firePoint.position, firePoint.right); // shoot raycast through the object called firepoint

        if (Hit.collider.CompareTag("Pinky")) // check if it hits an enemy through the use of tags
        {
            EnemyPinky Pinky = Hit.transform.GetComponent<EnemyPinky>(); // save the object that is hit
            Instantiate(impactEffectBlood, Hit.point, Quaternion.identity); // spawn a blood effect at the point of impact of the raycast
            Pinky.TakeDamage(damage); // make enemy take damage
        }
        else
        {
            Instantiate(impactEffectSpark, Hit.point, Quaternion.identity); // raycast did not hit an enemy
        }
        ammo--;

    }
    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            playerAudioPlayer.PlayAudio(AudioClips.Hurt);
        }
        else
        {
            return;
        }
    }
}
