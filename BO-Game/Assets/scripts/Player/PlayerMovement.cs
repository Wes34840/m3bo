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
    private Animator anim;
    private SpriteRenderer sprite;
    public FirePointUpdate UpdateFirePoint;

    [SerializeField] private float MovementSpeed = 7f;
    [SerializeField] private float JumpForce = 18f;
    private float dirX;
    private float dirY;

    private enum MovementState { idle, walking, firing, crouching, crouchWalk, crouchFiring, dying }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * MovementSpeed, rb.velocity.y);
        dirY = Input.GetAxisRaw("Vertical");

        if (dirY > 0 && IsGrounded()) 
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce);
        }

        UpdateSprite();

    }
    private void UpdateSprite()
    {

        MovementState state;

        if (dirX > 0 && !FacingRight)
        {
            // flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (dirX < 0 && FacingRight)
        {
            // flip the player.
            Flip();
        }

        if (dirX != 0) // player is walking
        {
            state = MovementState.walking;
            
            if (dirY < 0f && rb.velocity.y == 0) // if player is crouching, make player crouchwalk
            {
                state = MovementState.crouchWalk;
            }
        }
        else if (dirY < 0 && rb.velocity.y == 0) // checking stationary crouching input
        {
            state = MovementState.crouching;
            isCrouched = true;
            if (Input.GetButton("Fire1")) // firing while in crouched position
            {
                state = MovementState.crouchFiring;
                 
            }
        }
        else // otherwise idle
        {
            state = MovementState.idle;
            isCrouched = false;
            if (Input.GetButton("Fire1")) // play idle firing animation
            {
                state = MovementState.firing;
            }
        }

        anim.SetInteger("state", (int)state);
        
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private void Flip()
    {
        FacingRight = !FacingRight;  // player is no longer facing the direction it was facing according to the game

        transform.Rotate(0f, 180f, 0); // direction is mirrored
    }
    
    private void UpdatePointPosition() // this looks like a bad way of implementing it, but fuck it, it works for now
    {
        UpdateFirePoint.UpdatePosition(isCrouched);
    }
}
