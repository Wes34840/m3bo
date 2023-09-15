using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private bool FacingRight = true;
    [SerializeField] private bool isCrouched;
    public FirePointUpdate UpdateFirePoint;
    [SerializeField] private PlayerCombat combatScript;
    private PlayerSpriteUpdater spriteUpdater;

    [SerializeField] private float MovementSpeed = 6f;
    [SerializeField] private float JumpForce = 18f;
    private float dirX;
    private float dirY;
    private bool isDead = false;
    public bool HasKeyRed = false;



    public GameObject DeathScreen;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        combatScript = GetComponent<PlayerCombat>();
        spriteUpdater = GetComponent<PlayerSpriteUpdater>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (combatScript.health > 0)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * MovementSpeed, rb.velocity.y);
            dirY = Input.GetAxisRaw("Vertical");

            if (dirY > 0 && IsGrounded())
            {
                rb.velocity = new Vector3(rb.velocity.x, JumpForce); // jump
            }

            spriteUpdater.UpdateSprite(dirX, dirY, rb.velocity.y, FacingRight, combatScript.ammo); // update sprite
        }
        else if (combatScript.health <= 0 && isDead == false)
        {
            Die();
        }
        else
        {
            return;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    

    private void Die()
    {
        isDead = true; // shitty way of preventing Update() from spamming the function over and over
        spriteUpdater.ShowDeathSprite(combatScript.health);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX; // freeze position on x axis
    }

    

}
