using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private PlayerCombat combatScript;
    private AudioSource source;
    private ParticleSystem particle;
    public string Type;
    // Start is called before the first frame update
    
    void Start()
    {
        combatScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        source = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Type == "Ammo")
            {
                if (combatScript.ammo + 50 >= combatScript.MaxAmmo) // if ammo pickup causes ammo to be more than max
                {
                    combatScript.ammo = 200; // set ammo at max
                }
                else
                {
                    combatScript.ammo += 50;
                }
                source.Play();
                particle.Play();
                Destroy(transform.GetChild(0).gameObject);
                Destroy(gameObject, 0.5f);
            }
            else if (Type == "Healthpack")
            {
                if (combatScript.health + 50 >= combatScript.MaxHealth) // same as ammo
                {
                    combatScript.health = 200;
                }
                else
                {
                    combatScript.health += 50;
                }
                Destroy(gameObject);
            }
        }
    }
}
