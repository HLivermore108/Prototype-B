using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Lose health
            gameManager.TakeDamage();

            // Optional: play sound or particle
            // AudioSource.PlayClipAtPoint(hitSound, transform.position);
            // Instantiate(hitParticle, transform.position, Quaternion.identity);

            // Destroy the obstacle so it doesn’t hit again
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Coin"))
        {
            gameManager.score += 100;
            Destroy(other.gameObject);
        }
    }
}
