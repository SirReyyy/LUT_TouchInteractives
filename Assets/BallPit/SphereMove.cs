using UnityEngine;

public class SphereMove : MonoBehaviour
{
    public float speed = 1.0f; // Speed of the movement
    private float minY = -1.0f, maxY = 1.0f; // Maximum Y position
    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position;
        // Generate a random offset to determine the initial direction
        randomOffset = Random.Range(0f, (maxY - minY) / speed);
        speed = Random.Range(0.5f, 2.0f);
    }

    void Update()
    {
        float newY = Mathf.PingPong(Time.time * speed + randomOffset, maxY - minY) + minY;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
