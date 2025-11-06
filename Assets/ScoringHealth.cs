using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int health = 3;
    public TMPro.TextMeshProUGUI scoreText;
    public UnityEngine.UI.Slider healthBar;

    void Update()
    {
        score += (int)(Time.deltaTime * 10);
        scoreText.text = "Score: " + score;
    }

    public void TakeDamage()
    {
        health--;
        healthBar.value = health;
        if (health <= 0)
            GameOver();
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("LastScore", score);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
