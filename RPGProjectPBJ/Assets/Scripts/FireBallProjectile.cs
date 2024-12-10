using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBallProjectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private BoxCollider2D enemyCollider;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //looks at player and moves in that direction
        Vector2 lookToPlayer = (player.transform.position - transform.position).normalized;
        rb2d.AddForce(lookToPlayer * speed);
        //begins timer to destroy player.
        StartCoroutine(DestroyFireBall());
    }

    IEnumerator DestroyFireBall()
    {
        //maybe make cooldown longer idk?
        yield return new WaitForSeconds(12);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }


}
