using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public bool gameOver;
    public TextMeshProUGUI deathMessageText;
    public Image startScreen;
    public Image pauseScreen;
    public Image gameOverScreen;
    public bool lichExists;

    private SlimeController player;
    private EnemyHealth lich;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SlimeController>();
        
        gameOver = false;
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SlimeController>();
        if (lichExists)
        {
            lich = GameObject.FindGameObjectWithTag("Lich").GetComponent<EnemyHealth>();
            LichDied();
        }
        PlayerDied();
        GameOver();
        
        
    }

    void GameOver()
    {
        if(gameOver == true)
        {
            Time.timeScale = 0;
            gameOverScreen.gameObject.SetActive(true);
        }
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }
    public void PlayerDied()
    {
        if(player.realHealth <= 0)
        {
            gameOver = true;
            deathMessageText.text = "YOU DIED!";
        }
    }
    public void LichDied()
    {
        if(lich.healthEnemy <= 0)
        {
            gameOver = true;
            deathMessageText.text = "CONGRATS!\nYOU KILLED THE LICH!";
        }
    }
}
