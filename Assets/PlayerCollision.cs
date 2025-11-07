using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("References")]
    private ScoringHealth scoringHealth;

    private void Awake()
    {
        // Try to find the ScoringHealth component in the scene
        scoringHealth = FindFirstObjectByType<ScoringHealth>();
        if (scoringHealth == null)
            Debug.LogError("No ScoringHealth component found in scene! Make sure one exists.");
    }

    // Use OnCollisionEnter if obstacles have non-trigger colliders
    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    // Use OnTriggerEnter if obstacles or collectibles are triggers
    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject obj)
    {
        if (scoringHealth == null)
            return;

        if (obj.CompareTag("Obstacle"))
        {
            Debug.Log("Hit an obstacle: " + obj.name);
            scoringHealth.TakeDamage(20);
        }
        else if (obj.CompareTag("Collectible"))
        {
            Debug.Log("Collected: " + obj.name);
            scoringHealth.AddScore(10);
            Destroy(obj);
        }
    }
}
