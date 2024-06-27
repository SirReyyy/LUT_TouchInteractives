using UnityEngine;

public class PumpkinSpawner : MonoBehaviour
{
    public GameObject pumpkinPrefab; // Reference to the pumpkin prefab
    public Transform pumpkinHolder; // Reference to the parent transform
    public float spawnInterval = 0.5f; // Time interval between spawns
    private float minX = -1.8f, maxX = 1.8f; // Maximum x position for spawning

    void Start()
    {
        InvokeRepeating("SpawnPumpkin", 0f, spawnInterval); // Start spawning pumpkins at regular intervals
    }

    void SpawnPumpkin()
    {
        float randomX = Random.Range(minX, maxX); // Random x position within the specified range
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z); // Spawn position
        GameObject pumpkin = Instantiate(pumpkinPrefab, spawnPosition, Quaternion.identity); // Instantiate the pumpkin prefab at the spawn position
        pumpkin.transform.parent = pumpkinHolder; // Set the parent of the spawned pumpkin
    }
}
