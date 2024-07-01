using UnityEngine;

public class PoleTrigger : MonoBehaviour
{
    public float zPosition = 4.4f; // Original z position
    public float targetZPosition = 5.0f; // Target z position on trigger
    public float lerpSpeed = 2.0f; // Speed of lerp
    public Material[] materialsList; // List of materials for random color change

    private bool isTriggered = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Renderer poleRenderer;
    private Material originalMaterial;

    void Start()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, zPosition);
        endPosition = new Vector3(transform.position.x, transform.position.y, targetZPosition);
        poleRenderer = GetComponent<Renderer>();
        originalMaterial = poleRenderer.material; // Store the original material
    }

    void Update()
    {
        if (isTriggered)
        {
            // Lerp towards the target position
            transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime * lerpSpeed);
        }
        else
        {
            // Lerp back to the start position
            transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime * lerpSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
        ChangeColor();
    }

    void OnTriggerExit(Collider other)
    {
        isTriggered = false;
        // RevertColor();
    }

    void ChangeColor()
    {
        if (materialsList.Length > 0)
        {
            Material randomMaterial = materialsList[Random.Range(0, materialsList.Length)];
            poleRenderer.material = randomMaterial;
        }
    }

    void RevertColor()
    {
        poleRenderer.material = originalMaterial;
    }
}
