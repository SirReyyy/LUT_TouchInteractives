using UnityEngine;

public class BlackKeyScript : MonoBehaviour
{
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private float originalAlpha;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalAlpha = spriteRenderer.color.a; // Store the original alpha value
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Play the audio source
        }

        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = 250f; // Change the alpha to 0 (make the sprite transparent)
            spriteRenderer.color = color;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = originalAlpha; // Revert the alpha to original value
            spriteRenderer.color = color;
        }
    }
}
