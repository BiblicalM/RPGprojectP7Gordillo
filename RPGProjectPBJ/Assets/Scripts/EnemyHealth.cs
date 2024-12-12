using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public HealthUI enemyHealth;
    public GameObject soul;
    public int healthEnemy;
    public int maxHealthEnemy;
    // Start is called before the first frame update
    void Start()
    {
        healthEnemy = maxHealthEnemy;
        enemyHealth.SetMaxHealth(maxHealthEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealth.SetHealth(healthEnemy);
        EnemyDied();
    }

    public void TakeDamage(int damage)
    {
        healthEnemy -= damage;
    }
    void EnemyDied()
    {
        if (healthEnemy <= 0)
        {
            Instantiate(soul, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
