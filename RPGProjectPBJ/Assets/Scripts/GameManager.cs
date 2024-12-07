using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        if(gameOver == true)
        {
            Time.timeScale = 0;
        }
        
    }
}
