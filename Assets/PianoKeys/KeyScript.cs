using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color greenColor = Color.green; // Color to change to on trigger

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; // Store the original color
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (audioSource != null) {
            audioSource.Play(); // Play the audio source
        }

        if (spriteRenderer != null) {
            spriteRenderer.color = greenColor; // Change the sprite color to green
        }

        Debug.Log(gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        if (spriteRenderer != null) {
            spriteRenderer.color = originalColor; // Revert the sprite color to original
        }
    }
}
