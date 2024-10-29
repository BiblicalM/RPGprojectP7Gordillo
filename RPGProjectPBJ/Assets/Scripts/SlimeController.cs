using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlimeController : MonoBehaviour
{
    GameObject Player;
    private Rigidbody2D rb;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Player.transform.Translate(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);
        
    }
}
