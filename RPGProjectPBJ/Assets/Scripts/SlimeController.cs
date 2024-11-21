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
    public string powerType;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        //Vector2 Movement = (horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime);
        //transform.Translate(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);

        rb.velocity = new Vector2 (speed * horizontalInput * Time.deltaTime, verticalInput * speed * Time.deltaTime);
        //rb.AddForce(Movement);
        playerAnim.SetFloat("Speed_F", horizontalInput);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Corpse")
        {
            

        }
    }
}
