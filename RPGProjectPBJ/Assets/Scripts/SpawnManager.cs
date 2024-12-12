using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Transform spawnPos;
    public List<GameObject> enemies;
    public bool spawnEnemy;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = GetComponent<Transform>();
        StartCoroutine(SpawnEnemy());

    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(10);

        spawnEnemy = true;
        
    }
    public int GenerateEnemy()
    {
        int selectEnemy = Random.Range(0, enemies.Count);
        return selectEnemy;
    }
    
    void Spawn()
    {
        if(spawnEnemy == true)
        {

            Instantiate(enemies[GenerateEnemy()], spawnPos.position, spawnPos.rotation);
            spawnEnemy = false;
            StartCoroutine(SpawnEnemy());
        }
    }
}
