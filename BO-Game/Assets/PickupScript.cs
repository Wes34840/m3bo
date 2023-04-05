using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private PlayerCombat combatScript;
    private AudioSource source;
    private ParticleSystem particle;
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
            combatScript.ammo += 50;
            source.Play();
            particle.Play();
            Destroy(transform.GetChild(0).gameObject);
            Destroy(gameObject, 0.5f);
        }
    }
}
