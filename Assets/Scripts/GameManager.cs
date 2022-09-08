using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;

    public float speed;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Time increases by one every second the game runs. Every 15 seconds, the time is reset and the speed objects move increases.
        if (isGameActive)
        {
            time += Time.deltaTime;
            if (time >= 15)
            {
                time = 0;
                speed += 0.5f;
            }
        }
    }

    // Start the game when the Start button is pressed.
    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
    
    // Update the score counter when a point is earned from destroying Dirt.
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Bring up the Game Over text and Restart button when the player hits an obstacle.
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    // Return to the Title screen when the Restart button is hit.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
