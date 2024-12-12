using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SlimeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool coolDown = false;
    private BoxCollider2D playerCollider;
    public float speed = 10;

    public Animator playerAnim;
    private GameManager gameManager;
    public Animator slashEffect;
    private SpriteRenderer playerSprites;
    public string powerType;

    public int maxHealth = 20;
    
    public int realHealth;
    public int attackPower;
    public bool canAttack;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private bool isInvincible;

    public HealthUI healthBar;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        
        playerSprites = GetComponent<SpriteRenderer>();
        isInvincible = false;

        realHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        healthBar.SetHealth(realHealth);
        if (realHealth > maxHealth)
        {
            realHealth = maxHealth;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && coolDown == false && canAttack)
        {
            
            PlayerAttack();
        }
        
        
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
        
       if(verticalInput < 0 || verticalInput > 0)
       {
            playerAnim.SetBool("UpMove", true);
       }
        else
        {
            playerAnim.SetBool("UpMove", false);
        }

        //rb.AddForce(Movement);
        playerAnim.SetFloat("Speed_f", Mathf.Abs(rb.velocity.x));
        playerAnim.SetFloat("Speed_up", rb.velocity.y);

    }

   

    public void TakeDamage( int damage)
    {
        if(isInvincible == false)
        {
            realHealth -= damage;
            isInvincible = true;
            StartCoroutine(PlayerInvincible());
        }
        
    }
    void PlayerAttack()
    {
        slashEffect.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackPower);
            
            coolDown = true;
        }

        StartCoroutine(CoolDown());
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1);
        coolDown = false;

    }
    IEnumerator PlayerInvincible()
    {
        yield return new WaitForSeconds(1);

        isInvincible = false;   
    }

    public void SoulHeal(int souls)
    {
        
        

            realHealth += souls * 2;
            attackPower += souls;
            maxHealth += souls;
        
    }

    public void Weapons(int sharpness)
    {
        
            attackPower += sharpness;
        
    }

}
