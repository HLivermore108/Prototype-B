using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoringHealth : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text scoreText;
    public Slider healthBar;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public Button retryButton;
    public Button mainMenuButton;

    private int score = 0;
    private int health = 100;
    private bool isGameOver = false;

    private void Start()
    {
        UpdateUI();
        gameOverPanel.SetActive(false);

        // Hook up button events
        retryButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        if (isGameOver) return;
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            GameOver();
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        healthBar.value = health;
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Final Score: " + score;
        Time.timeScale = 0f; // pause the game
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // make sure a scene named "MainMenu" exists
    }
}
