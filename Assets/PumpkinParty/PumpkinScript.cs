using UnityEngine;

public class PumpkinScript : MonoBehaviour
{
    private float minScale = 0.3f, maxScale = 0.5f; // Maximum scale for the pumpkin
    private float minYRotation = 180f, maxYRotation = 230f; // Maximum Y rotation for the pumpkin
    private float destroyY = -5f; // Y position at which to destroy the pumpkin
    public float fallSpeed = 2.0f; // Speed at which the pumpkin falls

    void Start()
    {
        // Randomize scale
        float randomScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        // Randomize Y rotation
        float randomYRotation = Random.Range(minYRotation, maxYRotation);
        transform.rotation = Quaternion.Euler(0f, randomYRotation, 0f);
    }

    void Update()
    {
        // Move the pumpkin downwards
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Destroy the pumpkin if it falls below the destroyY position
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
