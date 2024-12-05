using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    
    public int damage;
    private Rigidbody2D enemyrb;
    private float strength = 100;
    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SlimeController>().TakeDamage(damage);
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 awayfromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            playerRb.AddForce(awayfromPlayer * strength, ForceMode2D.Impulse);
        }
    }


}
