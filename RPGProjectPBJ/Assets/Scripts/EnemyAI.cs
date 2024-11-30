using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float attackRange;
    

    private float distanceFromPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        Vector2 moveDirect = player.transform.position - transform.position;
        moveDirect.Normalize();


        


        if(distanceFromPlayer < attackRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

}
