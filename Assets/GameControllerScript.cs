using System;
using UnityEngine;
using UnityEngine.UI;
public class GameControllerScript : MonoBehaviour
{
    public Text scoreText; // UI Text to display the score
    public Text highScoreText; // UI Text to display the game over message
    public Button startButton; // UI Button to start the game
    public GameObject menu;

    public GameObject shipPrefab; // Prefab for the ship
    public Transform shipSpawnPoint; // Prefab for the asteroid
    GameObject currentShip; // Reference to the current ship instance

    int score = 0; // Current score
    int highScore = 0; // High score

    public bool isStarted = false; // Flag to check if the game has started
    public static GameControllerScript instance; // Singleton instance of the GameControllerScript

    private void Start()
    {
        instance = this; // Set the singleton instance to this GameControllerScript

        highScore = PlayerPrefs.GetInt("HighScore", 0); // Load the high score from PlayerPrefs
        highScoreText.text = "High Score: " + highScore; // Update the UI Text to display the high score

        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        score = 0;
        scoreText.text = "Score: " + score;

        if (currentShip != null)
        {
            Destroy(currentShip);
        }

        currentShip = Instantiate(shipPrefab, shipSpawnPoint.position, Quaternion.identity);

        menu.SetActive(false);
        isStarted = true;
    }


    public void increaseScore(int increment)
    {
        score += increment; // Increase the score by the specified increment
        scoreText.text = "Score: " + score; // Update the UI Text to display the new score

        if (score > highScore)
        {
            highScore = score; // Update the high score if the current score is greater
            highScoreText.text = "High Score: " + highScore; // Update the UI Text to display the new high score
            PlayerPrefs.SetInt("HighScore", highScore); // Save the new high score to PlayerPrefs
            PlayerPrefs.Save(); // Ensure the PlayerPrefs are saved
        }
    }

    public void GameOver()
    {
        isStarted = false;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            Destroy(obj);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Laser"))
        {
            Destroy(obj);
        }

        menu.SetActive(true);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        highScoreText.text = "Record: 0";
    }
}
