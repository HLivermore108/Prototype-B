using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 1.5f;
    public float spawnZ = 50f;
    public float laneWidth = 3f;

    void Start() => InvokeRepeating(nameof(SpawnObstacle), 1f, spawnRate);

    void SpawnObstacle()
    {
        int lane = Random.Range(-1, 2);
        Vector3 pos = new Vector3(lane * laneWidth, 0.5f, spawnZ);
        Instantiate(obstaclePrefab, pos, Quaternion.identity);
    }
}
