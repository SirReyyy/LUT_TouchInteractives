using UnityEngine;
using System.Collections;

public class SphereScale : MonoBehaviour
{
    // Define the target scale values
    public Vector3 minScale = new Vector3(0.3f, 0.3f, 0.3f); // Minimum scale
    public Vector3 maxScale = new Vector3(0.5f, 0.5f, 0.5f); // Maximum scale
    public float lerpSpeed = 2f; // Speed of interpolation

    private bool isScalingUp = false; // Flag to track if scaling up is in progress
    private bool isScalingDown = false; // Flag to track if scaling down is in progress
    private Vector3 currentScale; // To store the current scale

    private void OnTriggerEnter(Collider other)
    {
        if (!isScalingUp)
        {
            StartCoroutine(ScaleSphereUp());
        }
    }

    private IEnumerator ScaleSphereUp()
    {
        isScalingUp = true;
        float elapsedTime = 0f;
        Vector3 startScale = transform.localScale;

        while (elapsedTime < 1f)
        {
            transform.localScale = Vector3.Lerp(minScale, maxScale, elapsedTime);
            elapsedTime += Time.deltaTime * lerpSpeed;
            yield return null;
        }

        transform.localScale = maxScale; // Ensure we end at the max scale
        isScalingUp = false;

        // Store the current scale after scaling up completes
        currentScale = transform.localScale;

        // Start scaling down immediately after scaling up completes
        if (!isScalingDown)
        {
            StartCoroutine(ScaleSphereDown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Store the current scale when trigger exits
        currentScale = transform.localScale;

        // Start scaling down if not already scaling down
        if (!isScalingDown)
        {
            StartCoroutine(ScaleSphereDown());
        }
    }

    private IEnumerator ScaleSphereDown()
    {
        isScalingDown = true;
        float elapsedTime = 0f;
        Vector3 startScale = currentScale; // Use the stored currentScale

        while (elapsedTime < 1f)
        {
            transform.localScale = Vector3.Lerp(currentScale, minScale, elapsedTime);
            elapsedTime += Time.deltaTime * lerpSpeed;
            yield return null;
        }

        transform.localScale = minScale; // Ensure we end at the min scale
        isScalingDown = false;
    }
}
