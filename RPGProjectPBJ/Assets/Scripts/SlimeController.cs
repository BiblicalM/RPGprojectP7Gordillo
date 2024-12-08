using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlimeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    public float speed = 10;

    private Animator playerAnim;
    private SpriteRenderer playerSprites;
    public string powerType;

    public int maxHealth = 20;
    
    public int realHealth;
    public bool canAttack;
    public HealthUI healthBar;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerAnim = GetComponent<Animator>();
        playerSprites = GetComponent<SpriteRenderer>();

        realHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        healthBar.SetHealth(realHealth);
        healthBar.SetMaxHealth(maxHealth);
        

    }

    public void PlayerMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        //Vector2 Movement = (horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime);
        //transform.Translate(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);

        rb.velocity = new Vector2 (speed * horizontalInput * Time.deltaTime, verticalInput * speed * Time.deltaTime);
        if(horizontalInput < 0)
        {
            playerSprites.flipX = true;
        }
        else if(horizontalInput > 0)
        {
            playerSprites.flipX = false;
        }
        
       

        //rb.AddForce(Movement);
        playerAnim.SetFloat("Speed_f", Mathf.Abs(rb.velocity.x));
       

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Corpse")
        {
            

        }
    }

    public void TakeDamage( int damage)
    {
        realHealth -= damage;
        if(realHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
    void PlayerAttack()
    {

    }

}
