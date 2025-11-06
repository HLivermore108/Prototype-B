using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private ScoringHealth scoringHealth; 

    private void Start()
    {
        scoringHealth = FindFirstObjectByType<ScoringHealth>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            scoringHealth.TakeDamage(20);
        }
        else if (collision.gameObject.CompareTag("Collectible"))
        {
            scoringHealth.AddScore(10);
            Destroy(collision.gameObject);
        }
    }
}
