using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public HealthUI enemyHealth;
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
    }
}
