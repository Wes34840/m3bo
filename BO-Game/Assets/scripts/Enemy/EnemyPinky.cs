using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPinky : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    public Transform FirePoint;
    
    private enum AnimationState { idle, walking, bite, die }
    private AnimationState state;

    public int health = 100;
    private float MovementSpeed = 1000f;
    public int Damage = 40;
    private bool isDead = false;
    [SerializeField] private bool FacingRight = true;
    private bool isAttacking;
    private float dirX;
    private float lastDir;
    private float distanceBetween;

    [SerializeField] private PinkyThink ScuffedAILogic;
    [SerializeField] private PlayerCombat player;


    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        if (FirePoint.position.x < rb.position.x)
        {
            FacingRight = false;
        }
        player = GameObject.FindWithTag("Player").GetComponent<PlayerCombat>();
        ScuffedAILogic = GetComponent<PinkyThink>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        StartCoroutine(Unfreeze());
    }

    void Update()
    {
        if (!isDead)
        {
            MovePinky();

            UpdateSprite(); // update sprite

        }
        else if (isDead && state != AnimationState.die)
        {
            StartCoroutine(Die());
        }
        else
        {
            return;
        }
    }
    internal void MovePinky() // pinky is no longer lobotomized
    {
        

        distanceBetween = ScuffedAILogic.PosRelativeToPlayer(); // find distance between pinky and player
        dirX = ScuffedAILogic.GetDirX(distanceBetween); // find what direction the player is to the pinky

        if (distanceBetween > -3f && distanceBetween < 3f) // if inside proximity area
        {
            SnollebollekesMoment(lastDir);

        }
        else
        {
            rb.velocity = new Vector2(dirX * MovementSpeed * Time.deltaTime, rb.velocity.y); // walks into proximity area
            lastDir = dirX;
        }



    }
    private void SnollebollekesMoment(float direction)
    {
        rb.velocity = new Vector2(direction * MovementSpeed * Time.deltaTime, rb.velocity.y); // keep walking until out of proximity
    }
    public void TakeDamage(int damage)
    {
        health -= damage; // take damage

        rb.velocity = new Vector2(0, rb.velocity.y); // knockback (not implemented correctly l o  l), for now freezes enemy in place when hit
        

        if (health <= 0)
        {
            isDead = true;
        }
    }

    private IEnumerator Die()
    {
        state = AnimationState.die; 
        anim.SetInteger("state", (int)state);  //play death animation
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        Physics2D.IgnoreCollision(coll, GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        player.score += 500;
        // corpse cannot move left or right, no general freeze because it may cause an enemy to freeze mid-air 
        yield return new WaitForSeconds(10);
        Destroy(gameObject);    
    }
    private IEnumerator Unfreeze()
    {
        yield return new WaitForSeconds(0.7f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // unfreezes the pinky but also doesn't let it flip
    }

    private void UpdateSprite()
    {

        if (rb.velocity.x > 0 && !FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (rb.velocity.x < 0 && FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        if (rb.velocity.x != 0)
        {
            state = AnimationState.walking;
        }
        else
        {
            state = AnimationState.idle;
        }

        if (isAttacking)
        {
            state = AnimationState.bite;
        }

        anim.SetInteger("state", (int)state); // set sprite 
    }
    private void Flip()
    {
        FacingRight = !FacingRight;

        transform.Rotate(0f, 180f, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isAttacking= true;
        }
    }

    private void Bite()
    {
        RaycastHit2D[] Hits =  new RaycastHit2D[2]; // only 1 object is able to be hit, array has 2 values because the raycast keeps hitting the fucking pinky
        Hits = Physics2D.RaycastAll(FirePoint.position, FirePoint.right); // shoots raycast

        for (int i = 0; i < Hits.Length; i++)
        {
            Debug.Log(Hits[i]);

            if (Hits[i].collider.CompareTag("Player") && Hits[i].distance <= 0.5f) // checks if player is hit and in range
            {

                PlayerCombat Player = Hits[i].transform.GetComponent<PlayerCombat>();
                Player.TakeDamage(Damage); // does damage to player, could probably be implemented better but who cares lmao
                return; // related to isAttacking = false, this causes pinky to keep attacking if he hits you
            }
            
        }
        isAttacking = false; // stops attacking
    }
}
